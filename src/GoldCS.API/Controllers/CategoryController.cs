using GoldCS.Domain.Interfaces.Services;
using GoldCS.Domain.Models.Entities;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Models.Response;
using GoldCS.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GoldCS.API.Controllers
{
	[ApiController]
	[Route("api/category")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class CategoryController : MainController
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;

        public CategoryController(
				ICategoryService categoryService,
                IProductService productService,
				INotificationService notificationService
			) : base(notificationService)
		{
			_categoryService = categoryService;
			_productService = productService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var ret = await _categoryService.Get();
            return CustomResponse(ret);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetCategoryByIdAsync(int id)
		{
            var ret = await _categoryService.Get(id);
            return CustomResponse(ret);
        }

        [HttpGet("{categoryId:int}/products")]
		public async Task<IActionResult> GetProductsByCategoryAsync(int categoryId)
		{
            var ret = await _productService.GetFromCategory(categoryId);
            return CustomResponse(ret);
        }

        [HttpPost()]
        public async Task<IActionResult> InsertCategory([FromBody]CategoryRequests.Create request)
        {
			await _categoryService.Insert(request);
            return CustomResponse();

        }

        [HttpPut()]
        public async Task<IActionResult> Update(CategoryRequests.Alter request)
        {
            await _categoryService.Update(request);
            return CustomResponse();

        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteProductAsync(CategoryRequests.Deactivate request)
        {
            await _categoryService.Inactivate(request);
            return CustomResponse();
        }


    }
}