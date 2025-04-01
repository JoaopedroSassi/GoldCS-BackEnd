
namespace GoldCS.Domain.Models.Response
{
    public class LoginResponse : BaseResponse
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public int expiresIn { get; set; }
        public User UserData { get; set; }


        public override LoginResponse GerarCritica(int codigoCritica)
        {
            return new LoginResponse
            {
                Message = Criticas.RetornaCritica(codigoCritica),
                Success = false
            };
        }

        public override LoginResponse GerarRespostaSucessoPadrao()
        {
            return new LoginResponse
            {
                Success = true
            };
        }
    }
}
