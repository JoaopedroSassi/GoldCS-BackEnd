namespace src.Models.DTO.UserDTOS
{
	public class LoginReturnDTO
	{
		public string Token { get; set; }
		public string RefreshToken { get; set; }

		public LoginReturnDTO()
		{
		}

		public LoginReturnDTO(string token, string refreshToken)
		{
			Token = token;
			RefreshToken = refreshToken;
		}
	}
}