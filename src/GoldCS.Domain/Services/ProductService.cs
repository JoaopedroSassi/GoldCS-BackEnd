using GoldCS.Domain.Interfaces.Repository;
using GoldCS.Domain.Interfaces.Services;
using GoldCS.Domain.Models.Entities;

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

        public async Task<List<Product>> GetFromCategory(int categoryId)
        {
            var ret = await _productRepository.GetFromCategory(categoryId);

            if (ret is null)
            {
                AddMessage("Nenhum produto encontrado nessa categoria");
                return null;
            }

            return ret;
        }
    }
}
