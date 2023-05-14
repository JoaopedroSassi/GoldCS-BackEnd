using AutoMapper;
using src.Models.DTO.AddressDTOS;
using src.Models.Entities;

namespace src.Helpers
{
	public class AddressProfile : Profile
	{
		public AddressProfile()
		{
			CreateMap<AddressInsertDTO, Address>();
		}
	}
}