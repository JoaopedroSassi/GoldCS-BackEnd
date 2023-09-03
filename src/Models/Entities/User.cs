using src.Models.DTO.UserDTOS;

namespace src.Models.Entities
{
	public class User
	{
		public int UserID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public bool Active { get; set; }
		public string Role { get; set; }
		public List<Order> Orders { get; set; } = new();

		public User(int userID, string name, string email, string password, bool active, string role)
		{
			UserID = userID;
			Name = name;
			Email = email;
			Password = password;
			Active = active;
			Role = role;
		}

		public User()
		{
		}

		public User(UserRegisterDTO model)
		{
			Name = model.Name;
			Email = model.Email;
			Password = model.Password;
			Active = model.Active;
			Role = model.Role;
		}
    }
}