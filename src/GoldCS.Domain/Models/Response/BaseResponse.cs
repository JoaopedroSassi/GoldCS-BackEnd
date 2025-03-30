using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldCSDomain.Model.Response
{
    public class BaseResponse <TResult>
    {
        public bool success { get; set; }
        public DateTime dtResponse { get; set; }
        public string message { get; set; }
        public TResult result { get; set; }
    }
}
