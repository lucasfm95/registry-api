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
            var result = _productService.GetAll(pagination);

            if (result.Any())
            {
                return Ok(result);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductPostRequest productPostRequest)
        {
            var result = _productService.Add(productPostRequest);

            if (result is not null)
            {
                return Ok(result);
            }

            return BadRequest();
        }
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] string id, [FromBody] ProductPutRequest productPutRequest)
        {
            return Ok();
        }
    }
}

