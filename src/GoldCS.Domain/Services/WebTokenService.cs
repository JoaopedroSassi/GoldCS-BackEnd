using GoldCS.Domain.Interfaces;
using GoldCS.Domain.Models;
using GoldCS.Domain.Models.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GoldCS.Domain.Services
{
    public class WebTokenService : IWebTokenService
    {
        private readonly IConfiguration _configuration;

        public WebTokenService(IConfiguration configuration) 
        { 
            _configuration = configuration;
        }
        public LoginResponse ReturnResponseLogin(User user)
        {
            var expiresIn = Convert.ToInt32(_configuration["Jwt:ExpiresInSeconds"]);
            var accessToken = ObterToken(user, expiresIn);
            var refreshToken = Guid.NewGuid().ToString();

            return GenerateResponse(user, accessToken, refreshToken, expiresIn);
        }

        private string ObterToken(User user, int expiresIn)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim("name", user.Name.ToString()),
                }),
                Expires = DateTime.UtcNow.AddSeconds(expiresIn),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                ),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private LoginResponse GenerateResponse(User user, string accessToken, string refreshToken, int expiresIn)
        {
            return new LoginResponse
            {
                Success = true,
                UserData = user,
                access_token = accessToken,
                refresh_token = refreshToken,
                expiresIn = expiresIn
            };
        }
    }
}
