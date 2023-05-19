using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Extensions;
using src.Models.DTO.CategoryDTOS;
using src.Models.DTO.ProductDTOS;
using src.Pagination;
using src.Services.Interfaces;
using src.Utils;

namespace src.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _service;

		public CategoryController(ICategoryService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<CategoryDetailsDTO>>> GetCategoriesAsync([FromQuery] QueryPaginationParameters paginationParameters)
		{
			var categories = await _service.GetAllCategoriesAsync(paginationParameters);
			
			Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(new PaginationReturn(categories.TotalCount, categories.PageSize, categories.CurrentPage, categories.TotalPages, categories.hasNext, categories.hasPrevious)));

			ResponseUtil respUtil = new ResponseUtil(true, categories); 
			return Ok(respUtil);
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<CategoryDetailsDTO>> GetCategoryByIdAsync(int id)
		{
			if (id <= 0)
				ExceptionExtensions.ThrowBaseException("ID menor ou igual a 0", HttpStatusCode.NotFound);

			var category = await _service.GetCategoryByIdAsync(id);
			ResponseUtil respUtil = new ResponseUtil(true, category); 
			return Ok(respUtil);
		}

		[HttpGet("productsByCategory/{categoryId:int}")]
		public async Task<ActionResult<IEnumerable<ProductByCategoryDTO>>> GetProductsByCategoryAsync(int categoryId)
		{
			var products = await _service.GetProductsByCategoryAsync(categoryId);
			ResponseUtil respUtil = new ResponseUtil(true, products); 
			return Ok(respUtil);
		}

		[HttpPost]
		public async Task<ActionResult<string>> InsertCategoryAsync([FromBody] CategoryInsertDTO model)
		{
			if (!(ModelState.IsValid))
				ExceptionExtensions.ThrowBaseException("Formato inválido", HttpStatusCode.BadRequest);

			await _service.InsertCategoryAsync(model);
			ResponseUtil respUtil = new ResponseUtil(true, "Categoria inserida"); 
			return Ok(respUtil);
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult<CategoryDetailsDTO>> UpdateCategoryAsync(int id, [FromBody] CategoryUpdateDTO model)
		{
			if (model.CategoryID != id)
				ExceptionExtensions.ThrowBaseException("ID do parâmetro diferente do ID do corpo da requisição", HttpStatusCode.BadRequest);

			if (!(ModelState.IsValid))
				ExceptionExtensions.ThrowBaseException("Formato inválido", HttpStatusCode.BadRequest);

			await _service.UpdateCategoryAsync(model);
			ResponseUtil respUtil = new ResponseUtil(true, "Categoria atualizada com sucesso"); 
			return Ok(respUtil);
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<string>> DeleteCategoryAsync(int id)
		{
			if (id <= 0)
				ExceptionExtensions.ThrowBaseException("ID menor ou igual a 0", HttpStatusCode.NotFound);

			await _service.DeleteCategoryAsync(id);
			ResponseUtil respUtil = new ResponseUtil(true, "Categoria deletada com sucesso"); 
			return Ok(respUtil);
		}
	}
}