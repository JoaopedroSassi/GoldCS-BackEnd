using GoldCS.Domain.Models.Entities;
using GoldCS.Domain.Models.Response;
using GoldCS.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
	[ApiController]
	[Route("api/categories")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class CategoryController : ControllerBase
	{
		private readonly GoldCS.Domain.Interfaces.Services.ICategoryService _categoryService;
		private readonly GoldCS.Domain.Interfaces.Services.IProductService _productService;
		private readonly INotificationService _notificationService;

        public CategoryController(
				GoldCS.Domain.Interfaces.Services.ICategoryService categoryService,
                GoldCS.Domain.Interfaces.Services.IProductService productService,
				INotificationService notificationService
			) 
		{
			_notificationService = notificationService;
			_categoryService = categoryService;
			_productService = productService;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var ret = await _categoryService.Get();
			
			if (_notificationService.HasNotifications())
				return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));
			
			return Ok(new BaseResponse<List<Category>>().CriarSucesso(ret));
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetCategoryByIdAsync(int id)
		{
            var ret = await _categoryService.Get(id);

            if (_notificationService.HasNotifications())
                return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return Ok(new BaseResponse<Category>().CriarSucesso(ret));
        }

		[HttpGet("{categoryId:int}/products")]
		public async Task<IActionResult> GetProductsByCategoryAsync(int categoryId)
		{
            var ret = await _productService.GetFromCategory(categoryId);

            if (_notificationService.HasNotifications())
                return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return Ok(new BaseResponse<List<Product>>().CriarSucesso(ret));
        }
	}
}