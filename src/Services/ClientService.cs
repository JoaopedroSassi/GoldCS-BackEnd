using AutoMapper;
using src.Entities.DTO.Client;
using src.Entities.Models;
using src.Models.DTO.Client;
using src.Repositories.Interfaces;
using src.Services.Interfaces;

namespace src.Services
{
	public class ClientService : IClientService
	{
		private readonly IClientRepository _repository;
		private readonly IMapper _mapper;

		public ClientService(IClientRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<IEnumerable<ClientDetailsDTO>> GetAllClientsAsync()
		{
			return _mapper.Map<IEnumerable<ClientDetailsDTO>>(await _repository.GetClientsAsync());
		}

		public async Task<ClientDetailsDTO> GetClientByIdAsync(int id)
		{
			return _mapper.Map<ClientDetailsDTO>(await _repository.GetClientByIdAsync(id));
		}

		public async Task<bool> InsertClientAsync(ClientInsertDTO model)
		{
			Client client = _mapper.Map<Client>(model);

			_repository.Insert(client);	
			if (!(await _repository.SaveChangesAsync()))
				return false;

			return true;
		}
	}
}