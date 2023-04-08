using src.Entities.DTO.Client;
using src.Models.DTO.Client;
using src.Pagination;

namespace src.Services.Interfaces
{
	public interface IClientService
    {
        Task InsertClientAsync(ClientInsertDTO model);
		Task DeleteClientAsync(int id);
		Task<PagedList<ClientDetailsDTO>> GetAllClientsAsync(QueryPaginationParameters paginationParameters);
		Task<ClientDetailsDTO> GetClientByIdAsync(int id);
    }
}