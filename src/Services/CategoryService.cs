using System.Data;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using src.Exceptions;
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
			return _mapper.Map<IEnumerable<CategoryDetailsDTO>>(await _repository.GetCategoriesAsync());
		}

		public async Task<CategoryDetailsDTO> GetCategoryByIdAsync(int id)
		{
			return _mapper.Map<CategoryDetailsDTO>(await _repository.GetCategoryByIdAsync(id));
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

		public Task UpdateCategoryAsync(CategoryUpdateDTO model)
		{
			throw new NotImplementedException();
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