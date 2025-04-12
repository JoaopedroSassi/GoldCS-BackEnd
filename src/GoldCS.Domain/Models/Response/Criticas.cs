
namespace GoldCS.Domain.Models.Response
{
    public class Criticas
    {
        public const int ERROINTERNO = -1;
        public const int LOGININVALIDO = 1;
        public const int CREDENCIAISINVALIDAS = 2;
        public const int USUARIOINATIVO = 3;

        public static List<string> ReturnCritics(int codigo)
        {
            var ret = new List<string>();
            switch (codigo)
            {
                case LOGININVALIDO: ret.Add("Usuário não encontrado"); break;
                case CREDENCIAISINVALIDAS: ret.Add("Usuário ou senha incorretos."); break;
                case USUARIOINATIVO: ret.Add("Usuário bloqueado."); break;
                
                default: ret.Add("Ocorreu um erro interno"); break;
            }

            return ret;
        }


    }
}
