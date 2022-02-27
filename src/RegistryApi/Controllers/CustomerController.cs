using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistryApi.Core.Services.Interfaces;

namespace RegistryApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get() {

            var customers = _customerService.FindAll();

            return Ok(customers);
        }
    }
}
