using GoldCS.Domain.Interfaces.Services;
using GoldCS.Domain.Models.Request;
using GoldCS.Domain.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GoldCS.API.Controllers
{
    [ApiController]
    [Route("api/product")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductController : MainController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService service,
                            INotificationService notificationService) : base(notificationService)
        {
            _productService = service;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var products = await _productService.Get();
            return CustomResponse(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Obtain(int id)
        {
            var ret = await _productService.Get(id);
            return CustomResponse(ret);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] ProductRequests.Insert request)
        {
            await _productService.Insert(request);
            return CustomResponse();
        }

        [HttpPut()]
        public async Task<IActionResult> Update([FromBody] ProductRequests.Update request)
        {
            await _productService.Update(request);
            return CustomResponse();
        }

        [HttpDelete()]
        public async Task<IActionResult> Delete(ProductRequests.Inactivate request)
        {
            await _productService.Inactivate(request);
            return CustomResponse();
        }

        [HttpPost("insert-amount")]
        public async Task<IActionResult> InsertAmount(ProductRequests.InsertAmount request)
        {
            await _productService.InsertAmount(request);
            return CustomResponse();
        }
    }
}