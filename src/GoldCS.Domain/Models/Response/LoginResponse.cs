
namespace GoldCS.Domain.Models.Response
{
    public class LoginResponse
    {
        public string Access_token { get; set; }
        public string Refresh_token { get; set; }
        public int ExpiresIn { get; set; }
        public LoggedUser UserData { get; set; }

    }

    public class LoggedUser
    {
        public string  Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

}
