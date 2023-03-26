using src.Entities.DTO.Client;
using src.Models.DTO.Client;

namespace src.Services.Interfaces
{
	public interface IClientService
    {
        Task<bool> InsertClientAsync(ClientInsertDTO model);
		Task<IEnumerable<ClientDetailsDTO>> GetAllClientAsync();
		Task<ClientDetailsDTO> GetClientByIdAsync(int id);
    }
}