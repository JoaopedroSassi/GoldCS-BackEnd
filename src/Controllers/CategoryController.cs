using System.Net;
using Microsoft.AspNetCore.Mvc;
using src.Models.DTO.Category;
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
		public async Task<ActionResult<CategoryDetailsDTO>> GetCategoriasAsync()
		{
			return Ok(await _service.GetAllCategoriesAsync());
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<CategoryDetailsDTO>> GetCategoryByIdAsync(int id)
		{
			if (id <= 0)
			{
				var ex = new Exception("ID menor ou igual a 0");
				ex.Data.Add("StatusCode", HttpStatusCode.NotFound);
				throw ex;
			}
			
			return Ok(await _service.GetCategoryByIdAsync(id));
		}

		[HttpPost]
		public async Task<ActionResult<string>> InsertCategoryAsync([FromBody] CategoryInsertDTO model)
		{
			if (!(ModelState.IsValid))
			{
				var ex = new Exception("Formato inválido");
				ex.Data.Add("StatusCode", HttpStatusCode.NotFound);
				throw ex;
			}

			await _service.InsertCategoryAsync(model);
			return Ok("Categoria inserida");
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult<CategoryDetailsDTO>> UpdateCategoryAsync(int id, [FromBody] CategoryUpdateDTO model)
		{
			if (model.CategoryID != id)
			{
				var ex = new Exception("ID do parâmetro diferente do ID do corpo da requisição");
				ex.Data.Add("StatusCode", HttpStatusCode.BadRequest);
				throw ex;
			}

			if (!(ModelState.IsValid))
			{
				var ex = new Exception("Formato inválido");
				ex.Data.Add("StatusCode", HttpStatusCode.BadRequest);
				throw ex;
			}

			await _service.UpdateCategoryAsync(model);
			return Ok("Categoria atualizada com sucesso");
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<string>> DeleteCategoryAsync(int id) 
		{
			if (id <= 0)
			{
				var ex = new Exception("ID menor ou igual a 0");
				ex.Data.Add("StatusCode", HttpStatusCode.NotFound);
				throw ex;
			}

			await _service.DeleteCategoryAsync(id);
			return Ok("Categoria deletada");
		}
	}
}