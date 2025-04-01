
namespace GoldCS.Domain.Models.Response
{
    public class Criticas
    {
        public const int ERROINTERNO = -1;
        public const int LOGININVALIDO = 1;
        public const int CREDENCIAISINVALIDAS = 2;

        public static string RetornaCritica(int codigo)
        {
            switch (codigo)
            {
                case LOGININVALIDO: return "Usuário não encontrado";
                case CREDENCIAISINVALIDAS: return "Usuário ou senha incorretos.";
                
                default: return "Ocorreu um erro interno. Por favor entrar em contato com o suporte.";
            }
        }


    }
}
