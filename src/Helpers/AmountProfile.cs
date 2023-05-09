using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using src.Models.DTO.Amount;
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