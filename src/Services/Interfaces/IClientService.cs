using src.Models.DTO.ClientDTOS;

namespace src.Services.Interfaces
{
	public interface IClientService
    {
		Task<ClientDetailsDTO> GetClientByCpfAsync(string cpf);
    }
}