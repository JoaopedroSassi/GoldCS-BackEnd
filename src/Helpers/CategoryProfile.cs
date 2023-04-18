using AutoMapper;
using src.Models.DTO.Category;
using src.Models.Entities;

namespace src.Helpers
{
	public class CategoryProfile : Profile
	{
		public CategoryProfile()
		{
			CreateMap<Category, CategoryDetailsDTO>();
			CreateMap<CategoryDetailsDTO, Category>();

			CreateMap<Category, CategoryInsertDTO>();
			CreateMap<CategoryInsertDTO, Category>();

			CreateMap<Category, CategoryUpdateDTO>();
			CreateMap<CategoryUpdateDTO, Category>()
				.ForAllMembers(x => x.Condition((src, dest, srcMember) => srcMember != null));
		}
	}
}