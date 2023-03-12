using Microsoft.AspNetCore.Mvc;
using RegistryApi.Domain.Customers.Requests;

namespace RegistryApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Ok");
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductPostRequest productPostRequest)
        {
            return Ok("Ok");
        }
    }
}

