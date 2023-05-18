using System.Net;
using AutoMapper;
using src.Extensions;
using src.Models.DTO.ProductDTOS;
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
			var products = _mapper.Map<List<ProductDetailsDTO>>(await _repository.GetproductsAsync(paginationParameters));
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

		public async Task InsertAmountProductAsync(ProductAmountInsertDTO model)
		{
			var product = await _repository.GetProductByIdAsync(model.ProductID);
			if (product is null)
				ExceptionExtensions.ThrowBaseException("Produto não encontrado", HttpStatusCode.NotFound);

			if (model.Quantity < 0)
				ExceptionExtensions.ThrowBaseException("Impossível entrar com valores negativos", HttpStatusCode.BadRequest);

			product.Quantity += model.Quantity;
			_repository.Update(product);
			if (!(await _repository.SaveChangesAsync()))
				ExceptionExtensions.ThrowBaseException($"Erro ao adicionar estoque do produto '{product.Name}' no banco de dados", HttpStatusCode.BadRequest);
		}

		public async Task RemoveAmountProductsAsync(List<ProductAmountRemoveDTO> model)
		{
			List<Product> listProducts = new();
			for (int i = 0; i < model.Count; i++)
			{
				var product = await _repository.GetProductByIdAsync(model[i].ProductID);

				if (product is null)
				ExceptionExtensions.ThrowBaseException("Produto não encontrado", HttpStatusCode.NotFound);

				if (model[i].Quantity < 0)
					ExceptionExtensions.ThrowBaseException("Impossível entrar com valores negativos", HttpStatusCode.BadRequest);

				if (model[i].Quantity > product.Quantity)
					ExceptionExtensions.ThrowBaseException("Impossível remover mais estoque do que presente", HttpStatusCode.BadRequest);

				product.Quantity -= model[i].Quantity;
				listProducts.Add(product);
			}
			
			_repository.UpdateRange(listProducts);

			if (!(await _repository.SaveChangesAsync()))
				ExceptionExtensions.ThrowBaseException($"Erro ao remover estoque dos produtos no banco de dados", HttpStatusCode.BadRequest);
		}
	}
}