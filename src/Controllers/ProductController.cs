using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.Extensions;
using src.Models.DTO.ProductDTOS;
using src.Pagination;
using src.Services.Interfaces;
using src.Utils;

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

			ResponseUtil respUtil = new ResponseUtil(true, products); 
			return Ok(respUtil);
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<ProductDetailsDTO>> GetProductByIdAsync(int id)
		{
			if (id <= 0)
				ExceptionExtensions.ThrowBaseException("ID menor ou igual a 0", HttpStatusCode.NotFound);

			var product = await _service.GetProductByIdAsync(id);
			ResponseUtil respUtil = new ResponseUtil(true, product); 
			return Ok(respUtil);
		}

		[HttpPost]
		public async Task<ActionResult<string>> InsertProductAsync([FromBody] ProductInsertDTO model)
		{
			if (!(ModelState.IsValid))
				ExceptionExtensions.ThrowBaseException("Formato inválido", HttpStatusCode.BadRequest);

			await _service.InsertProductAsync(model);
			ResponseUtil respUtil = new ResponseUtil(true, "Produto inserido"); 
			return Ok(respUtil);
		}

		[HttpPost("insertAmount")]
		public async Task<ActionResult<string>> InsertAmountProductAsync([FromBody] ProductAmountInsertDTO model)
		{
			if (!(ModelState.IsValid))
				ExceptionExtensions.ThrowBaseException("Formato inválido", HttpStatusCode.BadRequest);

			await _service.InsertAmountProductAsync(model);
			ResponseUtil respUtil = new ResponseUtil(true, "Estoque inserido"); 
			return Ok(respUtil);
		}

		[HttpPut("{id:int}")]
		public async Task<ActionResult<ProductDetailsDTO>> UpdateProductAsync(int id, [FromBody] ProductUpdateDTO model)
		{
			if (!(ModelState.IsValid))
				ExceptionExtensions.ThrowBaseException("Formato inválido", HttpStatusCode.BadRequest);

			await _service.UpdateProductAsync(model, id);
			ResponseUtil respUtil = new ResponseUtil(true, "Produto atualizado com sucesso"); 
			return Ok(respUtil);
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<string>> DeleteProductAsync(int id)
		{
			if (id <= 0)
				ExceptionExtensions.ThrowBaseException("ID menor ou igual a 0", HttpStatusCode.NotFound);

			await _service.DeleteProductAsync(id);
			ResponseUtil respUtil = new ResponseUtil(true, "Produto deletado"); 
			return Ok(respUtil);
		}
    }
}