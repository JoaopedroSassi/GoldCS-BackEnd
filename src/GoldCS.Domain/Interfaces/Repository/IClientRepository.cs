using GoldCS.Domain.Models.Entities;

namespace GoldCS.Domain.Interfaces.Repository
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClients();
        Task<Client> GetclientById(int id);
        Task<Client> GetClientByCpf(string cpf);
        Task Insert (Client client);
        Task Update (Client client);

    }
}
