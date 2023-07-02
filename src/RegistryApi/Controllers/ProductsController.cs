using Microsoft.AspNetCore.Mvc;
using RegistryApi.Core.Services.Interfaces;
using RegistryApi.Domain.Products.Request;

namespace RegistryApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Ok");
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductPostRequest productPostRequest)
        {
            var result = _productService;//.Add(productPostRequest);

            if (result is not null)
            {
                return Ok("Ok");
            }

            return BadRequest();
        }
    }
}

