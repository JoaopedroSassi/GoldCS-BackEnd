using AutoMapper;
using src.Models.DTO.Product;
using src.Models.Entities;

namespace src.Helpers
{
	public class ProductProfile : Profile
    {
        public ProductProfile()
		{
			CreateMap<Product, ProductDetailsDTO>().ForMember(x => x.Category, y => y.MapFrom(y => y.Category.Name));
			CreateMap<ProductDetailsDTO, Product>();

			CreateMap<Product, ProductInsertDTO>();
			CreateMap<ProductInsertDTO, Product>();

			CreateMap<Product, ProductUpdateDTO>();
			CreateMap<ProductUpdateDTO, Product>();
		}
    }
}