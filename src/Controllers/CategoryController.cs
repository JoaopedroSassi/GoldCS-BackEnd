using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using src.Extensions;
using src.Models.DTO.Category;
using src.Pagination;
using src.Services.Interfaces;

namespace src.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
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

			return Ok(categories);
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<CategoryDetailsDTO>> GetCategoryByIdAsync(int id)
		{
			if (id <= 0)
				ExceptionExtensions.ThrowBaseException("ID menor ou igual a 0", HttpStatusCode.NotFound);

			return Ok(await _service.GetCategoryByIdAsync(id));
		}

		[HttpPost]
		public async Task<ActionResult<string>> InsertCategoryAsync([FromBody] CategoryInsertDTO model)
		{
			if (!(ModelState.IsValid))
				ExceptionExtensions.ThrowBaseException("Formato inválido", HttpStatusCode.BadRequest);

			await _service.InsertCategoryAsync(model);
			return Ok("Categoria inserida");
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult<CategoryDetailsDTO>> UpdateCategoryAsync(int id, [FromBody] CategoryUpdateDTO model)
		{
			if (model.CategoryID != id)
				ExceptionExtensions.ThrowBaseException("ID do parâmetro diferente do ID do corpo da requisição", HttpStatusCode.BadRequest);

			if (!(ModelState.IsValid))
				ExceptionExtensions.ThrowBaseException("Formato inválido", HttpStatusCode.BadRequest);

			await _service.UpdateCategoryAsync(model);
			return Ok("Categoria atualizada com sucesso");
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<string>> DeleteCategoryAsync(int id)
		{
			if (id <= 0)
				ExceptionExtensions.ThrowBaseException("ID menor ou igual a 0", HttpStatusCode.NotFound);

			await _service.DeleteCategoryAsync(id);
			return Ok("Categoria deletada");
		}
	}
}