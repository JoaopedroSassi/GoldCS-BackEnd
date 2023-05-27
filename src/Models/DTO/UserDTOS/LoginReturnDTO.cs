namespace src.Models.DTO.UserDTOS
{
	public class LoginReturnDTO
	{
		public string Token { get; set; }
		public string RefreshToken { get; set; }
		public int UserID { get; set; }
		public string Email { get; set; }
		public string Name { get; set; }
		public string Role { get; set; }

		public LoginReturnDTO()
		{
		}

		public LoginReturnDTO(string token, string refreshToken, int userID, string email, string name, string role)
		{
			Token = token;
			RefreshToken = refreshToken;
			UserID = userID;
			Email = email;
			Name = name;
			Role = role;
		}
	}
}