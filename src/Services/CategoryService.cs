using System.Net;
using AutoMapper;
using src.Models.DTO.Category;
using src.Models.DTO.Product;
using src.Models.Entities;
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

		public async Task<IEnumerable<CategoryDetailsDTO>> GetAllCategoriesAsync()
		{
			var categories = _mapper.Map<IEnumerable<CategoryDetailsDTO>>(await _repository.GetCategoriesAsync());
			if (!categories.Any())
			{
				var ex = new Exception("Sem categorias cadastradas");
				ex.Data.Add("StatusCode", HttpStatusCode.NotFound);
				throw ex;
			}
			
			return categories;
		}

		public async Task<CategoryDetailsDTO> GetCategoryByIdAsync(int id)
		{
			var category = _mapper.Map<CategoryDetailsDTO>(await _repository.GetCategoryByIdAsync(id));
			if (category is null)
			{
				var ex = new Exception("Categoria não encontrada");
				ex.Data.Add("StatusCode", HttpStatusCode.NotFound);
				throw ex;
			}

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
			{
				var ex = new Exception("Erro ao adicionar a categoria no banco de dados");
				ex.Data.Add("StatusCode", HttpStatusCode.BadRequest);
				throw ex;
			}
		}

		public async Task UpdateCategoryAsync(CategoryUpdateDTO model)
		{
			_repository.Update(_mapper.Map<Category>(model));
			if (!(await _repository.SaveChangesAsync()))
			{
				var ex = new Exception("Erro ao atualizar a categoria no banco de dados");
				ex.Data.Add("StatusCode", HttpStatusCode.BadRequest);
				throw ex;
			}
		}

		public async Task DeleteCategoryAsync(int id)
		{
			var category = await _repository.GetCategoryByIdAsync(id);
			if (category is null)
			{
				var ex = new Exception("Categoria não encontrado");
				ex.Data.Add("StatusCode", HttpStatusCode.NotFound);
				throw ex;
			}

			_repository.Delete(category);
			if (!(await _repository.SaveChangesAsync()))
			{
				var ex = new Exception("Erro ao deletar a categoria no banco de dados");
				ex.Data.Add("StatusCode", HttpStatusCode.BadRequest);
				throw ex;
			}
		}
	}
}