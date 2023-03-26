using AutoMapper;
using src.Entities.DTO.Client;
using src.Entities.Models;
using src.Models.DTO.Client;

namespace src.Helpers
{
	public class ClientProfile : Profile
    {
        public ClientProfile()
		{
			CreateMap<Client, ClientInsertDTO>();
			CreateMap<ClientInsertDTO, Client>();

			CreateMap<Client, ClientDetailsDTO>();
			CreateMap<ClientDetailsDTO, Client>();
		}
    }
}