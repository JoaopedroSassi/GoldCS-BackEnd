using src.Models.Entities;

namespace src.Models.DTO.UserDTOS
{
	public class UserGenerateTokenDTO
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
		public string Role { get; set; }

		public UserGenerateTokenDTO(int userID, string name, string email, string role)
		{
			UserID = userID;
			Name = name;
			Email = email;
			Role = role;
		}

		public UserGenerateTokenDTO()
		{
		}

		public UserGenerateTokenDTO(User user)
		{
			UserID = user.UserID;
			Name = user.Name;
			Email = user.Email;
			Role = user.Role;
		}
	}
}