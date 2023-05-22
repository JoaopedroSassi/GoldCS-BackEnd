using src.Models.Entities;

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

		public UserGenerateTokenDTO(User user)
		{
			UserID = user.UserID;
			Email = user.Email;
			Role = user.Role;
		}
	}
}