using System.Net;
using AutoMapper;
using src.Extensions;
using src.Models.DTO.Category;
using src.Models.DTO.Product;
using src.Models.Entities;
using src.Pagination;
using src.Repositories.Interfaces;
using src.Services.Interfaces;

namespace src.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _repository;
		private readonly IMapper _mapper;

		public CategoryService(ICategoryRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<PagedList<CategoryDetailsDTO>> GetAllCategoriesAsync(CategoriesParameters categoriesParameters)
		{
			var categories = _mapper.Map<List<CategoryDetailsDTO>>(await _repository.GetCategoriesAsync(categoriesParameters));
			if (!categories.Any())
				ExceptionExtensions.ThrowBaseException("Sem categorias cadastradas", HttpStatusCode.NotFound);

			return new PagedList<CategoryDetailsDTO>(categories, _repository.Count<Category>(), categoriesParameters.PageNumber, categoriesParameters.PageSize);
		}

		public async Task<CategoryDetailsDTO> GetCategoryByIdAsync(int id)
		{
			var category = _mapper.Map<CategoryDetailsDTO>(await _repository.GetCategoryByIdAsync(id));
			if (category is null)
				ExceptionExtensions.ThrowBaseException("Categoria não encontrada", HttpStatusCode.NotFound);

			return category;
		}

		public async Task<IEnumerable<ProductDetailsDTO>> GetProductsByCategoryAsync(int categoryId)
		{
			return _mapper.Map<IEnumerable<ProductDetailsDTO>>(await _repository.GetProductsByCategoryAsync(categoryId));
		}

		public async Task InsertCategoryAsync(CategoryInsertDTO model)
		{
			_repository.Insert(_mapper.Map<Category>(model));
			if (!(await _repository.SaveChangesAsync()))
				ExceptionExtensions.ThrowBaseException("Erro ao adicionar a categoria no banco de dados", HttpStatusCode.BadRequest);
		}

		public async Task UpdateCategoryAsync(CategoryUpdateDTO model)
		{
			_repository.Update(_mapper.Map<Category>(model));
			if (!(await _repository.SaveChangesAsync()))
				ExceptionExtensions.ThrowBaseException("Erro ao atualizar a categoria no banco de dados", HttpStatusCode.BadRequest);
		}

		public async Task DeleteCategoryAsync(int id)
		{
			var category = await _repository.GetCategoryByIdAsync(id);
			if (category is null)
				ExceptionExtensions.ThrowBaseException("Categoria não encontrada", HttpStatusCode.NotFound);

			_repository.Delete(category);
			if (!(await _repository.SaveChangesAsync()))
				ExceptionExtensions.ThrowBaseException("Erro ao deletar a categoria no banco de dados", HttpStatusCode.BadRequest);
		}
	}
}