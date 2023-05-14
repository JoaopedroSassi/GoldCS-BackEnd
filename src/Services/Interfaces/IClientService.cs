using src.Entities.DTO.ClientDTOS;
using src.Models.DTO.ClientDTOS;
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