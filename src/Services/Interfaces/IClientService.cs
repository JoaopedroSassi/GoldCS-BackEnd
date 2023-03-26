using src.Entities.DTO.Client;
using src.Entities.Models;

namespace src.Services.Interfaces
{
	public interface IClientService
    {
        ClientInsertDTO InsertClient(Client model);
    }
}