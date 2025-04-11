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
        public string Message { get; set; }
        public DateTime DtResponse { get; } = DateTime.Now;
        public T Result { get; set; }

        public BaseResponse<T> CriarSucesso(T objetoResponse)
        {
            return new BaseResponse<T>
            {
                Success = true,
                Result = objetoResponse
            };
        }
        public BaseResponse<T> GerarCritica(int codigoCritica)
        {
            return new BaseResponse<T>
            {
                Success = false,
                Message = Criticas.RetornaCritica(codigoCritica),
                Result = null
            };
        }
    }
}
