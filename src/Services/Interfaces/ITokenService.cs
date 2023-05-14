using src.Models.DTO.UserDTOS;

namespace src.Services.Interfaces
{
	public interface ITokenService
    {
        string GenerateToken(UserGenerateTokenDTO user);
    }
}