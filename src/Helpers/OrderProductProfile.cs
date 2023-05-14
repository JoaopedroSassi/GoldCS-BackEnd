using AutoMapper;
using src.Models.DTO.OrderProductDTOS;
using src.Models.Entities;

namespace src.Helpers
{
	public class OrderProductProfile : Profile
	{
		public OrderProductProfile()
		{
			CreateMap<OrderProductInsertDTO, OrderProduct>();
		}
	}
}