using System.Security.Claims;
using src.Models.DTO.UserDTOS;

namespace src.Services.Interfaces
{
	public interface ITokenService
    {
        string GenerateToken(UserGenerateTokenDTO user);
		string GenerateToken(IEnumerable<Claim> claims);
		string GenerateRefrehsToken();
		ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
		void SaveRefreshToken(string username, string refreshToken);
		string GetRefreshToken(string username);
		void DeleteRefreshToken(string username, string refreshToken);
    }
}