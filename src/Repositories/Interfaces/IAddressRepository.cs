using src.Models.Entities;
using src.Pagination;

namespace src.Repositories.Interfaces
{
	public interface IAddressRepository
    {
        Task<Address> GetAddressByIdAsync(int id);
		Task<List<Address>> GetAddressesAsync(QueryPaginationParameters paginationParameters);
    }
}