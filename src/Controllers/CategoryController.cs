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
			var categories = await _service.GetAllCategoriesAsync();
			if (!categories.Any())
			{
				var ex = new Exception("Sem categorias cadastradas");
				ex.Data.Add("StatusCode", HttpStatusCode.NotFound);
				throw ex;
			}

			return Ok(categories);
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
	}
}