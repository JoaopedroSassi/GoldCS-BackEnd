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
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly INotificationService _notificationService;

        public CategoryController(
				ICategoryService categoryService,
                IProductService productService,
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

            if (_notificationService.HasNotifications()) return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return Ok(new BaseResponse<List<Product>>().CriarSucesso(ret));
        }
        
		[HttpPost()]
        public async Task<IActionResult> InsertCategory([FromBody]CategoryRequests.Create request)
        {
			await _categoryService.Insert(request);

            if (_notificationService.HasNotifications()) return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return StatusCode((int) HttpStatusCode.Created);
        }
        
		[HttpPut()]
        public async Task<IActionResult> Update(CategoryRequests.Alter request)
        {
            await _categoryService.Update(request);

            if (_notificationService.HasNotifications()) return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return StatusCode((int)HttpStatusCode.NoContent);
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteProductAsync(CategoryRequests.Deactivate request)
        {
            await _categoryService.Inactivate(request);

            if (_notificationService.HasNotifications()) return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return StatusCode((int)HttpStatusCode.NoContent);
        }


    }
}