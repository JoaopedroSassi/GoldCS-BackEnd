using GoldCS.Domain.Interfaces.Repository;
using GoldCS.Domain.Interfaces.Services;
using GoldCS.Domain.Models.Entities;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Models.Response;

namespace GoldCS.Domain.Services
{
    public class ProductService : BaseValidationService, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(
            IProductRepository productRepository,
            INotificationService notificationService) : base(notificationService)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductResponse>> Get()
        {
            var ret = await _productRepository.Get();

            if (ret is null)
            {
                AddMessage("Nenhum produto encontrado");
                return null;
            }

            return ret.Select(product => new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                InclusionDate = product.InclusionDate,
                Active = product.Active,
                CategoryId = product.CategoryId,
                CostPrice = product.CostPrice,
                Height = product.Height,
                MeasureType = product.MeasureType,
                Stock = product.Stock,
                Width = product.Width
            }).ToList();
        }

        public async Task<ProductResponse> Get(int id)
        {
            var ret = await _productRepository.Get(id);

            if (ret is null)
            {
                AddMessage("Nenhum produto encontrado");
                return null;
            }

            return new ProductResponse
            {
                Id = ret.Id,
                Name = ret.Name,
                Description = ret.Description,
                InclusionDate = ret.InclusionDate,
                Active = ret.Active,
                CategoryId = ret.CategoryId,
                CostPrice = ret.CostPrice,
                Height = ret.Height,
                Width = ret.Width,
                MeasureType = ret.MeasureType,
                Stock = ret.Stock
            };
        }

        public async Task<List<ProductResponse>> GetFromCategory(int categoryId)
        {
            var ret = await _productRepository.GetFromCategory(categoryId);

            if (ret is null)
            {
                AddMessage("Nenhum produto encontrado nessa categoria");
                return null;
            }

            return ret.Select(product => new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                InclusionDate = product.InclusionDate,
                Active = product.Active,
                CategoryId = product.CategoryId,
                CostPrice = product.CostPrice,
                Height = product.Height,
                MeasureType = product.MeasureType,
                Width = product.Width,
                Stock = product.Stock
            }).ToList();
        }

        public async Task Insert(ProductRequests.Insert request)
        {
            if (!await ExecuteValidationsAsync(new InsertProductValidations(), request))
            {
                return;
            }

            Product insert = new()
            {
                Name = request.Name,
                Description = request.Description,
                CostPrice = request.CostPrice,
                CategoryId = request.CategoryId,
                Height = request.Height,
                Width = request.Width,
                Stock = request.Stock,
                MeasureType = request.MeasureType,
                Active = true, 
                InclusionDate = DateTime.Now
            };

            await _productRepository.Insert(insert);
        }

        public async Task InsertAmount(ProductRequests.InsertAmount request)
        {
            if (!await ExecuteValidationsAsync(new InsertAmountValidations(), request))
            {
                return;
            }
            
            var product = await _productRepository.Get(request.ProductId);
            
            if (product is null)
            {
                AddMessage("Nenhum produto encontrado");
                return;
            }
            
            if(product.Active is false)
            {
                AddMessage("Não é possível inserir estoque em um produto excluído");
                return;
            }

            await _productRepository.InsertAmount(request.AmountToInsert, product);
        }

        public async Task Update(ProductRequests.Update request)
        {
            if (!await ExecuteValidationsAsync(new UpdateProductValidations(), request))
            {
                return;
            }

            var product = await _productRepository.Get(request.Id);

            if (product is null)
            {
                AddMessage("Nenhum produto encontrado");
                return;
            }

            if (product.Active is false)
            {
                AddMessage("Não é possível atualizar um produto excluído");
                return;
            }

            product.Name = request.Name;
            product.Description = request.Description;
            product.CostPrice = request.CostPrice;
            product.Height = request.Height;
            product.Width = request.Width;
            product.MeasureType = request.MeasureType;

            await _productRepository.Update(product);
        }

        public async Task Inactivate(ProductRequests.Inactivate request)
        {
            if (!await ExecuteValidationsAsync(new DeleteProductValidations(), request)) return;
            
            await _productRepository.Inactivate(request.ProductId);
        }
    }

}
