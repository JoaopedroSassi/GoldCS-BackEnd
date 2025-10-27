using Azure.Core;
using GoldCS.Domain.Interfaces.Services;
using GoldCS.Domain.Models.Entities;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Models.Response;
using GoldCS.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace src.Controllers
{
    [ApiController]
    [Route("api/product")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly INotificationService _notificationService;

        public ProductController(IProductService service,
                            INotificationService notificationService)
        {
            _productService = service;
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var products = await _productService.Get();

            if (_notificationService.HasNotifications()) return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return Ok(new BaseResponse<List<Product>>().CriarSucesso(products));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Obtain(int id)
        {
            var ret = await _productService.Get(id);

            if (_notificationService.HasNotifications()) return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return Ok(new BaseResponse<Product>().CriarSucesso(ret));
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ProductRequests.Insert request)
        {
            await _productService.Insert(request);

            if (_notificationService.HasNotifications()) return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return StatusCode(201);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateProductAsync([FromBody] ProductRequests.Update request)
        {
            await _productService.Update(request);

            if (_notificationService.HasNotifications()) return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return StatusCode(204);
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteProductAsync(ProductRequests.Inactivate request)
        {
            await _productService.Inactivate(request);

            if (_notificationService.HasNotifications()) return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return StatusCode(204);
        }

        [HttpPost("insert-amount")]
        public async Task<IActionResult> InsertAmount(ProductRequests.InsertAmount request)
        {

            await _productService.InsertAmount(request);

            if (_notificationService.HasNotifications()) return BadRequest(new BaseResponse().CustomCritics(_notificationService.GetNotifications()));

            return StatusCode(204);
        }
    }
}