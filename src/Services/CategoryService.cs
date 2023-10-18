using System.Net;
using GoldCSAPI.Extensions;
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

		public CategoryService(ICategoryRepository repository)
		{
			_repository = repository;
		}

		public async Task<PagedList<CategoryDetailsDTO>> GetAllCategoriesAsync(QueryPaginationParameters paginationParameters)
		{
			var categoriesDB = await _repository.GetCategoriesAsync(paginationParameters);
			var categories = categoriesDB.Select(x => new CategoryDetailsDTO(x)).ToList();

			if (!categories.Any())
				ExceptionExtensions.ThrowBaseException("Sem categorias cadastradas", HttpStatusCode.NotFound);

			return new PagedList<CategoryDetailsDTO>(categories, _repository.Count<Category>(), paginationParameters.PageNumber, paginationParameters.PageSize);
		}

		public async Task<CategoryDetailsDTO> GetCategoryByIdAsync(int id)
		{
			var categoryDB = await _repository.GetCategoryByIdAsync(id);

			var category = new CategoryDetailsDTO(categoryDB);
			if (category is null)
				ExceptionExtensions.ThrowBaseException("Categoria não encontrada", HttpStatusCode.NotFound);

			return category;
		}

		public async Task<IEnumerable<ProductByCategoryDTO>> GetProductsByCategoryAsync(int categoryId)
		{
			var productsByCatDB = await _repository.GetProductsByCategoryAsync(categoryId);
			var productsByCat = productsByCatDB.Select(x => new ProductByCategoryDTO(x)).ToList();

			if (!productsByCat.Any())
				ExceptionExtensions.ThrowBaseException("Sem produtos para essa categoria", HttpStatusCode.NotFound);

			return productsByCat;
		}

		public async Task InsertCategoryAsync(CategoryInsertDTO model)
		{
			_repository.Insert(new Category(model));
			if (!(await _repository.SaveChangesAsync()))
				ExceptionExtensions.ThrowBaseException("Erro ao adicionar a categoria no banco de dados", HttpStatusCode.BadRequest);
		}

		public async Task UpdateCategoryAsync(CategoryUpdateDTO model, int id)
		{
			var category = await _repository.GetCategoryByIdAsync(id);
            if (category is null)
                ExceptionExtensions.ThrowBaseException("Produto não encontrado", HttpStatusCode.NotFound);

            category = (Category) UpdateEntityExtension.UpdateEntityProperties(category, new Category(model));

            _repository.Update(category);
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