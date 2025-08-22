using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldCS.Domain.Util
{

    public enum OrderStatus
    {
        Received,
        Paid,
        InTransport,
        Delivered,
        Archived,
        Canceled
    }

    public enum AdressType
    {
        Comercial, 
        Residential,
    }

}
