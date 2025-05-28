using src.Models.Entities;

namespace src.Repositories.Interfaces
{
	public interface IAddressRepository : IBaseRepository
    {
        Task<Address> GetAddressByCep(string cep);
    }
}