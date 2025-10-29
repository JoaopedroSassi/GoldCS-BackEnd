using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldCS.Domain.Interfaces
{
    public interface IUnityOfWork
    {
        Task IniciarTransacao();
        Task<bool> Commit();
        void Rollback(); 
    }
}
