namespace GoldCSAPI.Models.DTO.UserDTOS
{
    public class UserUpdateDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserUpdateDTO() { }

        public UserUpdateDTO(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
