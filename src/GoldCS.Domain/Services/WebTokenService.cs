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
        private static long ToUnixEpochDate(DateTime date) => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

        public WebTokenService(IConfiguration configuration) 
        { 
            _configuration = configuration;
        }
        public BaseResponse<LoginResponse> ReturnResponseLogin(User user)
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
                Issuer = _configuration["Jwt:Issuer"],
                Subject = new ClaimsIdentity(
                [
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, "admin"),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.Name),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64),
                    new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString())
                ]),
                Expires = DateTime.UtcNow.AddSeconds(expiresIn),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                ),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private BaseResponse<LoginResponse> GenerateResponse(User user, string accessToken, string refreshToken, int expiresIn)
        {
            var loggedUser = new LoggedUser
            {
                Email = user.Email,
                Name = user.Name,
                Id = user.UserId,
            };

            var loginResponse = new LoginResponse
            {
                access_token = accessToken,
                refresh_token = refreshToken,
                expiresIn = expiresIn,
                UserData = loggedUser
            };

            return new BaseResponse<LoginResponse>
            {
                Success = true,
                Result = loginResponse
            };
        }
    }
}
