using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebshopAPI.Lib;

namespace WebshopAPI.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    [Authorize("Admin")]
    public class AdminController : BaseController
    {
        #region User function

        UserManagerService userManagerService;

        public AdminController(UserManagerService userManagerService)
        {
            this.userManagerService = userManagerService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> ListUsers()
        {
            APIResponse response = new APIResponse();
            try
            {
                using (SQL sql = new SQL())
                {
                    var users = sql.Users.OrderBy(a => a.Name).ToList();
                    foreach (var user in users)
                    {
                        user.Password = "";
                    }
                    response.Data = users;
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                response.StatusCode = 101;
                response.Message = e.Message;
            }
            return BadRequest(response);
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(string email)
        {
            APIResponse response = new APIResponse();
            try
            {
                using (SQL sql = new SQL())
                {
                    if (sql.Users.Any(a => a.Email == email))
                    {
                        User user = sql.Users.Single(a => a.Email == email);
                        user.Password = String.Empty;
                        response.Data = user;
                        return Ok(response);
                    }
                    else
                    {
                        throw new UserNotFoundException();
                    }
                }
            }
            catch (UserNotFoundException)
            {
                response.StatusCode = 102;
                response.Message = $"A megadott e-mail című felhasználó nem létezik! E-mail cím: {email}!";
            }
            catch (Exception e)
            {
                response.StatusCode = 103;
                response.Message = e.Message;
            }
            await $"A felhasználó lekérése sikertelen:\r\nUser: {email}".WriteLogAsync(this._CurrentUser);
            return BadRequest(response);
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            APIResponse response = new APIResponse();
            try
            {
                await userManagerService.UpdateUser(user, this._CurrentUser);
                return Accepted(response);
            }
            catch (MandatoryPropertyEmptyException e)
            {
                response.StatusCode = 104;
                response.Message = e.Message;
            }
            catch (UserNotFoundException)
            {
                response.StatusCode = 105;
                response.Message = $"A megadott e-mail című user {user.Email} nem létezik!";
            }
            catch (Exception e)
            {
                response.StatusCode = 106;
                response.Message = e.Message;
            }
            await $"Felhasználó módosítás sikertelen:\r\nUser: {user.Dump()},\r\nException: {response.Dump()}".WriteLogAsync(this._CurrentUser);
            return BadRequest(response);
        }


        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            APIResponse response = new APIResponse();
            try
            {
                if (user.Password == null)
                {
                    throw new PasswordMissingException();
                }
                Encryption enc = Encryption.Initialize();
                user.Password = enc.EncyptPassword(user.Password);

                ObjectValidatorService<User> uValid = new ObjectValidatorService<User>(user);
                uValid.IsValid();
                await this.userManagerService.CreateUser(user);
                await $"Új dolgozó rögzítése:\r\n{user.Dump()}".WriteLogAsync(this._CurrentUser);
                return Ok(response);
            }
            catch (EmailRegisteredException)
            {
                response.StatusCode = 107;
                response.Message = "A megadott e-mail cím már regisztrálva van!";
            }
            catch (InvalidPropertyValueException e)
            {
                response.StatusCode = 108;
                response.Message = e.Message;
            }
            catch (MandatoryPropertyEmptyException e)
            {
                response.StatusCode = 109;
                response.Message = e.Message;
            }
            catch (PasswordMissingException)
            {
                response.StatusCode = 110;
                response.Message = "Kötelező a jelszó megadása!";
            }
            catch (Exception e)
            {
                response.StatusCode = 111;
                response.Message = e.Message;
            }
            await $"Új dolgozó rögzítése sikertelen:\r\nUser: {user.Dump()},\r\nException: {response.Dump()}".WriteLogAsync(this._CurrentUser);
            return BadRequest(response);
        }

        [HttpGet("SearchUser")]
        public async Task<IActionResult> SearchUser(string searchstring)
        {
            APIResponse response = new APIResponse();
            try
            {
                using (SQL sql = new SQL())
                {
                    IEnumerable<User> users = sql.Users.Where(a => a.Email.Contains(searchstring) || a.Name.Contains(searchstring)).Select(a => new User()
                    {
                        Email = a.Email,
                        Name = a.Name,
                        Description = a.Description,
                        LastLogon = a.LastLogon,
                        Enabled = a.Enabled,
                        UserType = a.UserType
                    }).ToList();
                    return Ok(users);
                }
            }
            catch (Exception e)
            {
                response.StatusCode = 112;
                response.Message = e.Message;
            }
            await $"A felhasználók keresése sikertelen:\r\nSearchstring: {searchstring}".WriteLogAsync(this._CurrentUser);
            return BadRequest(response);
        }
        #endregion
    }
}
