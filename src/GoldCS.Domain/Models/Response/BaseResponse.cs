using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldCS.Domain.Models.Response
{
    public abstract class BaseResponse 
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public abstract BaseResponse GerarCritica(int codigoCritica);
        public abstract BaseResponse GerarRespostaSucessoPadrao();

    }
}
