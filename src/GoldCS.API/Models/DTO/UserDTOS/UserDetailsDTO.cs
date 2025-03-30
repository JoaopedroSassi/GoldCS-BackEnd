using src.Models.Entities;

namespace GoldCSAPI.Models.DTO.UserDTOS
{
    public class UserDetailsDTO
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; }

        public UserDetailsDTO()
        {
        }

        public UserDetailsDTO(int userID, string name, string email, string role, bool active)
        {
            UserID = userID;
            Name = name;
            Email = email;
            Role = role;
            Active = active;
        }

        public UserDetailsDTO(User model)
        {
            UserID = model.UserID;
            Name = model.Name;
            Email = model.Email;
            Role = model.Role;
            Active = model.Active;
        }
    }
}
