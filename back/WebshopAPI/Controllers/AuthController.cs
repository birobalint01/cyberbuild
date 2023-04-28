using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebshopAPI.Lib;
using WebshopAPI.Lib.Database;
using WebshopAPI.Lib.Security;
using WebshopAPI.Lib.Services;
using WebshopCommon.Models;

namespace WebshopAPI.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        UserManagerService userManagerService;
        public AuthController(UserManagerService userManagerService)
        {
            this.userManagerService = userManagerService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login loginData)
        {
            using (SQL sql = new SQL())
            {
                if (sql.Users.Any(a => a.Email == loginData.Email))
                {
                    User user = sql.Users.Single(a => a.Email == loginData.Email);
                    if (!user.Enabled)
                    {
                        return Unauthorized();
                    }

                    Encryption enc = Encryption.Initialize(user.Password);
                    if (enc.Validate(loginData.Password))
                    {
                        AccessToken token = TokenHandlerService.GenerateToken(user);

                        user.LastLogon = DateTime.Now;
                        await sql.SaveChangesAsync();

                        user.Password = null;
                        token.UserData = user;
                        return Ok(new APIResponse<AccessToken>()
                        {
                            Data = token
                        });

                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
            return Unauthorized();

        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration([FromBody] Registration registration)
        {
            APIResponse response = new APIResponse();

            try
            {
                if (string.IsNullOrEmpty(registration.Password) || string.IsNullOrEmpty(registration.PasswordConfirmation))
                {
                    throw new PasswordMissingException();
                }

                if (registration.Password != registration.PasswordConfirmation)
                {
                    throw new PwdAndPwdConfirmationNotMatchedException();
                }

                ObjectValidatorService<Registration> regValid = new ObjectValidatorService<Registration>(registration);
                regValid.IsValid();

                Encryption enc = Encryption.Initialize();


                User user = new User()
                {
                    Email = registration.Email,
                    Name = registration.Name,
                    Password = enc.EncyptPassword(registration.Password),
                    UserType = EUserType.Customer,
                    Enabled = true
                };

                await userManagerService.CreateUser(user);
                await $"Regisztráció sikeres: \r\n{user.Dump()}".WriteLogAsync();
                return Ok(response);

            }
            catch (PasswordMissingException)
            {
                response.StatusCode = 401;
                response.Message = "A jelszó mezőt kötelező kitölteni!";
            }
            catch (PwdAndPwdConfirmationNotMatchedException)
            {
                response.StatusCode = 402;
                response.Message = "A jelszó és a jelszó megerősítés nem egyezik!";
            }
            catch (InvalidPropertyValueException e)
            {
                response.StatusCode = 403;
                response.Message = e.Message;
            }
            catch (MandatoryPropertyEmptyException e)
            {
                response.StatusCode = 404;
                response.Message = e.Message;
            }
            catch (EmailRegisteredException)
            {
                response.StatusCode = 405;
                response.Message = $"Ezzel az email címmel már regisztráltak! Email: {registration.Email}";
            }
            catch (Exception e)
            {
                response.StatusCode = 406;
                response.Message = e.Message;
            }
            await $"Regisztráció sikertelen:\r\nUser: {registration.Dump()},\r\nException: {response.Dump()}".WriteLogAsync();
            return BadRequest(response);
        }
    }


}
