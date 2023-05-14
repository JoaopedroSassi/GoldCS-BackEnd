using System.Net;
using AutoMapper;
using src.Extensions;
using src.Models.DTO.CategoryDTOS;
using src.Models.DTO.ProductDTOS;
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

		public async Task<PagedList<CategoryDetailsDTO>> GetAllCategoriesAsync(QueryPaginationParameters paginationParameters)
		{
			var categories = _mapper.Map<List<CategoryDetailsDTO>>(await _repository.GetCategoriesAsync(paginationParameters));
			if (!categories.Any())
				ExceptionExtensions.ThrowBaseException("Sem categorias cadastradas", HttpStatusCode.NotFound);

			return new PagedList<CategoryDetailsDTO>(categories, _repository.Count<Category>(), paginationParameters.PageNumber, paginationParameters.PageSize);
		}

		public async Task<CategoryDetailsDTO> GetCategoryByIdAsync(int id)
		{
			var category = _mapper.Map<CategoryDetailsDTO>(await _repository.GetCategoryByIdAsync(id));
			if (category is null)
				ExceptionExtensions.ThrowBaseException("Categoria não encontrada", HttpStatusCode.NotFound);

			return category;
		}

		public async Task<IEnumerable<ProductByCategoryDTO>> GetProductsByCategoryAsync(int categoryId)
		{
			var productsByCat = _mapper.Map<List<ProductByCategoryDTO>>(await _repository.GetProductsByCategoryAsync(categoryId));
			if (!productsByCat.Any())
				ExceptionExtensions.ThrowBaseException("Sem produtos para essa categoria", HttpStatusCode.NotFound);

			return productsByCat;
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

			var totalProducts = await _repository.GetCountProductsByCategoryAsync(id);
			if (totalProducts > 0)
				ExceptionExtensions.ThrowBaseException("Não é possível deletar uma categoria com produtos associados", HttpStatusCode.Conflict);

			_repository.Delete(category);
			if (!(await _repository.SaveChangesAsync()))
				ExceptionExtensions.ThrowBaseException("Erro ao deletar a categoria no banco de dados", HttpStatusCode.BadRequest);
		}
	}
}