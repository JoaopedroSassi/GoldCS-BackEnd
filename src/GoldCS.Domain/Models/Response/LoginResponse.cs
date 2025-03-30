using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldCSDomain.Model.Response
{
    public class LoginResponse : BaseResponse<LoginResponse>
    {
        string Token { get; set; }
        string RefreshToken { get; set; }
        User User { get; set; }

    }
}
