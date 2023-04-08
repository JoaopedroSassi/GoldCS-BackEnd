using AutoMapper;
using src.Models.DTO.Product;
using src.Models.Entities;

namespace src.Helpers
{
	public class ProductProfile : Profile
    {
        public ProductProfile()
		{
			CreateMap<Product, ProductDetailsDTO>();
			CreateMap<ProductDetailsDTO, Product>();

			CreateMap<Product, ProductInsertDTO>();
			CreateMap<ProductInsertDTO, Product>();

			CreateMap<Product, ProductUpdateDTO>();
			CreateMap<ProductUpdateDTO, Product>();
		}
    }
}