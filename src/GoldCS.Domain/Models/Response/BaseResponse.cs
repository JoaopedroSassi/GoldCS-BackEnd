using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldCS.Domain.Models.Response
{
    public class BaseResponse<T> where T : class 
    {
        public bool Success { get; set; }
        public DateTime DtHora { get; } = DateTime.Now;
        public List<string> Messages { get; set; }
        public T Result { get; set; }

        public BaseResponse<T> CriarSucesso(T objetoResponse)
        {
            return new BaseResponse<T>
            {
                Success = true,
                Result = objetoResponse
            };
        }
        public BaseResponse<T> GenerateCritic(int codigoCritica)
        {
            return new BaseResponse<T>
            {
                Success = false,
                Messages = Criticas.ReturnCritics(codigoCritica),
                Result = null
            };
        }
    }

    public class BaseResponse
    {
        public bool Success { get; set; }
        public DateTime DtHora { get; } = DateTime.Now;
        public List<string> Messages { get; set; } = new();

        public BaseResponse CustomCritics(List<string> critics)
        {
            return new BaseResponse
            {
                Success = false,
                Messages = critics,
            };
        }
    }

}
