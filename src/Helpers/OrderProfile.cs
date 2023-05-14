using AutoMapper;
using src.Models.DTO.OrderDTOS;
using src.Models.Entities;

namespace src.Helpers
{
	public class OrderProfile : Profile
    {
        public OrderProfile()
		{
			CreateMap<Order, OrderDetailsDTO>()
				.ForMember(x => x.UserID, x => x.MapFrom(x => x.User.UserID))
				.ForMember(x => x.UserEmail, x => x.MapFrom(x => x.User.Email))
				.ForMember(x => x.UserName, x => x.MapFrom(x => x.User.Name))
				;
				//.ForMember(x => x.CategoryName, x => x.MapFrom(x => x.Category.Name));

			CreateMap<OrderInsertDTO, Order>();
		}
    }
}