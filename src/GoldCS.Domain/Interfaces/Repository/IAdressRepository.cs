using GoldCS.Domain.Models.Entities;

namespace GoldCS.Domain.Interfaces.Repository
{
    public interface IAdressRepository
    {
        Task<Adress> FindByCepAndClientId(string cep, int clientId);
        Task Insert (Adress adress);
        Task Update (Adress adress);
    }
}
