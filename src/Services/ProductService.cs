using System.Net;
using AutoMapper;
using src.Extensions;
using src.Models.DTO.Product;
using src.Models.Entities;
using src.Pagination;
using src.Repositories.Interfaces;
using src.Services.Interfaces;

namespace src.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _repository;
		private readonly IMapper _mapper;

		public ProductService(IProductRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public async Task<PagedList<ProductDetailsDTO>> GetAllProductsAsync(QueryPaginationParameters paginationParameters)
		{
			var t = await _repository.GetproductsAsync(paginationParameters);
			var products = _mapper.Map<List<ProductDetailsDTO>>(t);
			if (!products.Any())
				ExceptionExtensions.ThrowBaseException("Sem produtos cadastrados", HttpStatusCode.NotFound);

			return new PagedList<ProductDetailsDTO>(products, _repository.Count<Product>(), paginationParameters.PageNumber, paginationParameters.PageSize);
		}

		public async Task<ProductDetailsDTO> GetProductByIdAsync(int id)
		{
			var product = _mapper.Map<ProductDetailsDTO>(await _repository.GetProductByIdAsync(id));
			if (product is null)
				ExceptionExtensions.ThrowBaseException("Produto não encontrado", HttpStatusCode.NotFound);

			return product;
		}

		public async Task InsertProductAsync(ProductInsertDTO model)
		{
			_repository.Insert(_mapper.Map<Product>(model));
			if (!(await _repository.SaveChangesAsync()))
				ExceptionExtensions.ThrowBaseException("Erro ao adicionar a categoria no banco de dados", HttpStatusCode.BadRequest);
		}

		public async Task UpdateProductAsync(ProductUpdateDTO model)
		{
			_repository.Update(_mapper.Map<Product>(model));
			if (!(await _repository.SaveChangesAsync()))
				ExceptionExtensions.ThrowBaseException("Erro ao atualizar o produto no banco de dados", HttpStatusCode.BadRequest);
		}

		public async Task DeleteProductAsync(int id)
		{
			var product = await _repository.GetProductByIdAsync(id);
			if (product is null)
				ExceptionExtensions.ThrowBaseException("Produto não encontrado", HttpStatusCode.NotFound);

			_repository.Delete(product);
			if (!(await _repository.SaveChangesAsync()))
				ExceptionExtensions.ThrowBaseException("Erro ao deletar o produto no banco de dados", HttpStatusCode.BadRequest);
		}
	}
}