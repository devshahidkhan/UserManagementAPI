using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagementWebAPI.Data.Entities;
using UserManagementWebAPI.Services.Auth.Interfaces;

namespace UserManagementWebAPI.Services.Auth.Implementation
{
    public class JwtTokenService(IConfiguration _configuration) : IJwtTokenService
    {
        public async Task<string> GenerateTokenAsync(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("APITokenKey")["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Audience = "abcxyzxyedh",
            //    Issuer = "www.hkxljsxiuwhuxhusxnoz.com",
            //    Subject = new ClaimsIdentity(claims),
            //    Expires = DateTime.Now.AddHours(1),
            //    SigningCredentials = creds
            //};


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _configuration["JwtSettings:Audience"],
                Issuer = _configuration["JwtSettings:Issuer"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            JwtSecurityTokenHandler tokenHandler1 = tokenHandler;
            return tokenHandler.WriteToken(token);
        }  
    }
}
