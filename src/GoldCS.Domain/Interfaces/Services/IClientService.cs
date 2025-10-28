using GoldCS.Domain.Models.Entities;
using GoldCS.Domain.Models.Request;

namespace GoldCS.Domain.Interfaces.Services
{
    public interface IClientService
    {
        Task<List<Client>> GetClients();
        Task<Client> GetClientByCpf(ClientRequests.GetByCpf request);
        Task<Client> GetClientById(int id);
        Task RegisterClient(ClientRequests.RegisterClient request);
        Task UpdateClient(ClientRequests.UpdateClient request);

    }
}
