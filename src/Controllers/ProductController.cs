using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Extensions;
using src.Models.DTO.ProductDTOS;
using src.Pagination;
using src.Services.Interfaces;

namespace src.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

		public ProductController(IProductService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProductDetailsDTO>>> GetProductsAsync([FromQuery] QueryPaginationParameters paginationParameters)
		{
			var products = await _service.GetAllProductsAsync(paginationParameters);
			
			Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(new PaginationReturn(products.TotalCount, products.PageSize, products.CurrentPage, products.TotalPages, products.hasNext, products.hasPrevious)));

			return Ok(products);
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<ProductDetailsDTO>> GetProductByIdAsync(int id)
		{
			if (id <= 0)
				ExceptionExtensions.ThrowBaseException("ID menor ou igual a 0", HttpStatusCode.NotFound);

			return Ok(await _service.GetProductByIdAsync(id));
		}

		[HttpPost]
		public async Task<ActionResult<string>> InsertProductAsync([FromBody] ProductInsertDTO model)
		{
			if (!(ModelState.IsValid))
				ExceptionExtensions.ThrowBaseException("Formato inválido", HttpStatusCode.BadRequest);

			await _service.InsertProductAsync(model);
			return Ok("Produto inserido");
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult<ProductDetailsDTO>> UpdateProductAsync(int id, [FromBody] ProductUpdateDTO model)
		{
			if (model.ProductID != id)
				ExceptionExtensions.ThrowBaseException("ID do parâmetro diferente do ID do corpo da requisição", HttpStatusCode.BadRequest);

			if (!(ModelState.IsValid))
				ExceptionExtensions.ThrowBaseException("Formato inválido", HttpStatusCode.BadRequest);

			await _service.UpdateProductAsync(model);
			return Ok("Produto atualizado com sucesso");
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<string>> DeleteProductAsync(int id)
		{
			if (id <= 0)
				ExceptionExtensions.ThrowBaseException("ID menor ou igual a 0", HttpStatusCode.NotFound);

			await _service.DeleteProductAsync(id);
			return Ok("Produto deletado");
		}
    }
}