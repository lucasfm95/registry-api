using Microsoft.AspNetCore.Mvc;
using RegistryApi.Core.Services.Interfaces;
using RegistryApi.Domain.Products.Request;
using RegistryApi.Domain.Request;

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
        public IActionResult GetAll([FromQuery] PaginationRequest pagination)
        {
            return Ok(_productService.GetAll(pagination));
        }

        [HttpGet("{code:int}")]
        public IActionResult GetByCode([FromRoute] int code)
        {
            var product = _productService.GetByCode(code);

            if (product is null)
            {
                return NoContent();
            }
            
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductPostRequest? productPostRequest)
        {
            if (productPostRequest is null)
            {
                return BadRequest("Product is required");
            }
            
            var result = _productService.Add(productPostRequest);

            return Ok(result);
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] string id, [FromBody] ProductPutRequest productPutRequest)
        {
            return Ok();
        }
    }
}

