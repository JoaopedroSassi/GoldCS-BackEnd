using src.Entities.Models;

namespace src.Repositories.Interfaces
{
	public interface IClientRepository : IBaseRepository
    {
        Task<Client> GetClientByIdAsync(int id);
		Task<IEnumerable<Client>> GetClientsAsync();
    }
}