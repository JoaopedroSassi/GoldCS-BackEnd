using GoldCS.Domain.Interfaces.Repository;
using GoldCS.Domain.Interfaces.Services;
using GoldCS.Domain.Models.Entities;


namespace GoldCS.Domain.Services
{
    public class CategoryService : BaseValidationService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(
            ICategoryRepository categoryRepository,
            INotificationService notificationService) : base(notificationService)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Get(int id)
        {
            var ret = await _categoryRepository.Get(id);
            
            if (ret is null)
            {
                AddMessage("Categoria não encontrada"); 
                return null;
            }

            return ret;
        }

        public async Task<List<Category>> Get()
        {
            return await _categoryRepository.Get();
        }

    }
}
