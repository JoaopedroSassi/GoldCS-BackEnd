using GoldCS.Domain.Interfaces.Repository;
using GoldCS.Domain.Interfaces.Services;
using GoldCS.Domain.Models.Entities;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Models.Response;


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

        public async Task<CategoryResponse> Get(int id)
        {
            var ret = await _categoryRepository.Get(id);
            
            if (ret is null)
            {
                AddMessage("Categoria não encontrada"); 
                return null;
            }

            return new CategoryResponse 
            { 
                Id = ret.Id,
                Name = ret.Name,
                Description = ret.Description,
                Active = ret.Active,
                InclusionDate = ret.InclusionDate,
            };
        }

        public async Task<List<CategoryResponse>> Get()
        {
            var ret =  await _categoryRepository.Get();

            return ret.Select(category => new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Active = category.Active,
                InclusionDate = category.InclusionDate
            }).ToList();
        }

        public async Task Insert(CategoryRequests.Create request)
        {
            if (!await ExecuteValidationsAsync(new InsertCategoryValidations(), request))
            {
                return;
            }

            Category insert = new()
            {
                Name = request.Name,
                Description = request.Description,
                Active = true,
                InclusionDate = DateTime.Now,
            };

            await _categoryRepository.Insert(insert);
        }

        public async Task Update(CategoryRequests.Alter request)
        {
            if (!await ExecuteValidationsAsync(new UpdateCategoryValidations(), request))
            {
                return;
            }
            
            var category = await _categoryRepository.Get(request.Id);

            if (category is null)
            {
                AddMessage("Nenhuma categoria encontrada");
                return;
            }

            if (category.Active is false)
            {
                AddMessage("Não é possível alterar uma categoria inativa");
                return;
            }

            category.Name = request.Name;
            category.Description = request.Description;

            await _categoryRepository.Update(category);

        }

        public async Task Inactivate(CategoryRequests.Deactivate request)
        {
            if (await ExecuteValidationsAsync(new DeleteCategoryValidations(), request) is false)
            {
                return; 
            }

            await _categoryRepository.Inactivate(request.CategoryId);

        }
    }
}
