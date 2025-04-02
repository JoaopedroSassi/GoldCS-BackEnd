
namespace GoldCS.Domain.Models.Response
{
    public class LoginResponse
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public int expiresIn { get; set; }
        public LoggedUser UserData { get; set; }

    }

    public class LoggedUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

}
