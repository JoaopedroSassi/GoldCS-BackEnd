using src.Models.DTO.User;

namespace src.Services.Interfaces
{
	public interface ITokenService
    {
        string GenerateToken(UserGenerateTokenDTO user);
    }
}