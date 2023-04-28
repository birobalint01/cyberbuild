using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebshopAPI.Lib.Database;

namespace WebshopAPI.Lib.Services
{
    public class TokenHandlerService
    {
        public static AccessToken GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.Name)
            };
            using (SQL sql = new SQL())
            {
                user.Roles = sql.UserRoles.Where(a => a.Email == user.Email).ToList();
                user.Roles.Select(a => a.RoleID).ToList().ForEach(a =>
                {
                    claims.Add(new Claim(ClaimTypes.Role, a.ToString()));
                });
            }
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Audience = Program.Audience,
                Issuer = Program.Issuer,
                Expires = DateTime.Now.AddHours(8),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Program.JWTKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AccessToken()
            {
                Token = tokenHandler.WriteToken(token),
                ExpireAt = token.ValidTo
            };
        }
    }
}
