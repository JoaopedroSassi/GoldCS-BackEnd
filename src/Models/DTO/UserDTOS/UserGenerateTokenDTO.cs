namespace src.Models.DTO.UserDTOS
{
	public class UserGenerateTokenDTO
    {
        public int UserID { get; set; }
		public string Email { get; set; }
		public string Role { get; set; }

		public UserGenerateTokenDTO(int userID, string email, string role)
		{
			UserID = userID;
			Email = email;
			Role = role;
		}

		public UserGenerateTokenDTO()
		{
		}
	}
}