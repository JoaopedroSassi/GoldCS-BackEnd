using AutoMapper;
using src.Entities.DTO.ClientDTOS;
using src.Entities.Models;
using src.Models.DTO.ClientDTOS;

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