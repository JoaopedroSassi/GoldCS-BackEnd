using src.Entities.DTO.Client;
using src.Models.DTO.Client;

namespace src.Services.Interfaces
{
	public interface IClientService
    {
        Task InsertClientAsync(ClientInsertDTO model);
		Task DeleteClientAsync(int id);
		Task<IEnumerable<ClientDetailsDTO>> GetAllClientsAsync();
		Task<ClientDetailsDTO> GetClientByIdAsync(int id);
    }
}