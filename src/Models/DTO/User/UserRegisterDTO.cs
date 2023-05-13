namespace src.Models.DTO.User
{
	public class UserRegisterDTO
    {
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public bool Active { get; set; }
		public string Role { get; set; }

		public UserRegisterDTO(string name, string email, string password, string role)
		{
			Name = name;
			Email = email;
			Password = password;
			Active = true;
			Role = role;
		}

		public UserRegisterDTO()
		{
		}
	}
}