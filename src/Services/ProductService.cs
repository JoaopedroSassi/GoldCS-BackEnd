using System.Net;
using System.Reflection;
using GoldCSAPI.Extensions;
using src.Extensions;
using src.Models.DTO.OrderProductDTOS;
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

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedList<ProductDetailsDTO>> GetAllProductsAsync(QueryPaginationParameters paginationParameters)
        {
            var productsDB = await _repository.GetproductsAsync(paginationParameters);
            var products = productsDB.Select(x => new ProductDetailsDTO(x)).ToList();

            if (!products.Any())
                ExceptionExtensions.ThrowBaseException("Sem produtos cadastrados", HttpStatusCode.NotFound);

            return new PagedList<ProductDetailsDTO>(products, _repository.Count<Product>(), paginationParameters.PageNumber, paginationParameters.PageSize);
        }

        public async Task<ProductDetailsDTO> GetProductByIdAsync(int id)
        {
            var productDB = await _repository.GetProductByIdAsync(id);

            var product = new ProductDetailsDTO(productDB);
            if (product is null)
                ExceptionExtensions.ThrowBaseException("Produto não encontrado", HttpStatusCode.NotFound);

            return product;
        }

        public async Task InsertProductAsync(ProductInsertDTO model)
        {
            _repository.Insert(new Product(model));
            if (!(await _repository.SaveChangesAsync()))
                ExceptionExtensions.ThrowBaseException("Erro ao adicionar a categoria no banco de dados", HttpStatusCode.BadRequest);
        }

        public async Task UpdateProductAsync(ProductUpdateDTO model, int id)
        {
            var product = await _repository.GetProductByIdAsync(id);
            if (product is null)
                ExceptionExtensions.ThrowBaseException("Produto não encontrado", HttpStatusCode.NotFound);

            product = (Product) UpdateEntityExtension.UpdateEntityProperties(product, model);            

            _repository.Update(product);
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

        public async Task RemoveAmountProductsAsync(ProductAmountRemoveDTO model)
        {
            var product = await _repository.GetProductByIdAsync(model.ProductID);

            if (product is null)
                ExceptionExtensions.ThrowBaseException("Produto não encontrado", HttpStatusCode.NotFound);

            if (model.Quantity < 0)
                ExceptionExtensions.ThrowBaseException("Impossível entrar com valores negativos", HttpStatusCode.BadRequest);

            if (model.Quantity > product.Quantity)
                ExceptionExtensions.ThrowBaseException("Impossível remover mais estoque do que presente", HttpStatusCode.BadRequest);

            product.Quantity -= model.Quantity;
            _repository.Update(product);
        }

        public async Task VerifyPriceProduct(OrderProductInsertDTO model)
        {
            var product = await _repository.GetProductByIdAsync(model.ProductID);

            if (model.FinalPrice < product.Price)
                ExceptionExtensions.ThrowBaseException($"ERRO - Preço do produto abaixo do mínimo | Produto: {product.Name}", HttpStatusCode.NotFound);
        }
    }
}