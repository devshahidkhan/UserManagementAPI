using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagementWebAPI.Services.Interfaces;
using UserEntity = UserManagementWebAPI.Data.Entities.User;

namespace UserManagementWebAPI.Services.Implementation
{
    public class JwtTokenService(ConfigurationManager configuration) : IJwtTokenService
    {
        public Task<string> GenerateTokenAsync(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("APITokenKey")["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "abcxyzxyedh",
                Issuer = "www.hkxljsxiuwhuxhusxnoz.com",
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            JwtSecurityTokenHandler tokenHandler1 = tokenHandler;
            return tokenHandler1.WriteToken(user);
        }  
    }
}
