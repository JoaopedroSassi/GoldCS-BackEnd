using AutoMapper;
using src.Models.DTO.ProductDTOS;
using src.Models.Entities;

namespace src.Helpers
{
	public class ProductProfile : Profile
    {
        public ProductProfile()
		{
			CreateMap<Product, ProductDetailsDTO>()
				.ForMember(x => x.CategoryName, x => x.MapFrom(x => x.Category.Name));
			CreateMap<ProductDetailsDTO, Product>();

			CreateMap<Product, ProductInsertDTO>();
			CreateMap<ProductInsertDTO, Product>();

			CreateMap<Product, ProductUpdateDTO>();
			CreateMap<ProductUpdateDTO, Product>()
				.ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));;

			CreateMap<Product, ProductByCategoryDTO>();
		}
    }
}