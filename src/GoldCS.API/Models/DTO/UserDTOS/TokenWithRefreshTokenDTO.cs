namespace src.Models.DTO.UserDTOS
{
	public class TokenWithRefreshTokenDTO
    {
        public string Token { get; set; }
		public string RefreshToken { get; set; }

		public TokenWithRefreshTokenDTO()
		{
		}

		public TokenWithRefreshTokenDTO(string token, string refreshToken)
		{
			Token = token;
			RefreshToken = refreshToken;
		}
    }
}