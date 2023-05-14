using AutoMapper;
using src.Models.DTO.AmountDTOS;
using src.Models.Entities;

namespace src.Helpers
{
	public class AmountProfile : Profile
	{
		public AmountProfile()
		{
			CreateMap<Amount, AmountInsertDTO>();
			CreateMap<AmountInsertDTO, Amount>();
		}
	}
}