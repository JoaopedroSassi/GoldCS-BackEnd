using GoldCS.Domain.Interfaces.Repository;
using GoldCS.Domain.Interfaces.Services;
using GoldCS.Domain.Models.Entities;
using GoldCS.Domain.Models.Request;

namespace GoldCS.Domain.Services
{
    public class ClientService : BaseValidationService, IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(
            IClientRepository clientRepository,
            INotificationService notificationService) : base(notificationService) 
        {
            _clientRepository = clientRepository;
        }
        public async Task<List<Client>> GetClients()
        {
            return await _clientRepository.GetClients();
        }


        public async Task<Client> GetClientByCpf(ClientRequests.GetByCpf request)
        {
            if (await ExecuteValidationsAsync(new GetByCpfValidations(), request) is false)
            {
                return null;
            }

            var ret = await _clientRepository.GetClientByCpf(request.Cpf);
            
            if (ret is null)
            {
                AddMessage("Não foi encontrado nenhum cliente com este CPF.");
                return null; 
            }
            
            return ret;
        }

        public async Task<Client> GetClientById(int id)
        {
            var ret = await _clientRepository.GetclientById(id);
            
            if (ret is null)
            {
                AddMessage("Não foi encontrado nenhum cliente com este id.");
                return null;
            }

            return ret;
        }

        public async Task RegisterClient(ClientRequests.RegisterClient request)
        {
            if (await ExecuteValidationsAsync(new RegisterValidations(), request) is false)
            {
                return;
            }

            var client = new Client
            {
                Name = request.Name,
                Cpf = request.Cpf,
                Email = request.Email,
                CellPhone = request.CellPhone,
                Phone = request.Phone,
                RegisterDate = DateTime.Now,
            };

            await _clientRepository.Insert(client); 
        }

        public async Task UpdateClient(ClientRequests.UpdateClient request)
        {
            if (await ExecuteValidationsAsync(new UpdateClientValidations(), request) is false)
            {
                return;
            }

            var client = await _clientRepository.GetclientById(request.Id); 

            if (client is null)
            {
                AddMessage("Nenhum cliente encontrado com este id.");
                return;
            }

            client.Email = request.Email;
            client.CellPhone = request.CellPhone;
            client.Phone = request.Phone;
            client.Name = request.Name;

            await _clientRepository.Update(client);
        }
    }
}
