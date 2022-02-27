using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegistryApi.Core.Services.Interfaces;
using RegistryApi.Domain.Customers.Request;

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
        public IActionResult GetAll() {

            var customers = _customerService.GetAll();

            return Ok(customers);
        }

        [HttpGet("{documentNumber}")]
        public IActionResult GetByDocumentNumber([FromRoute] string documentNumber)
        {
            var customer = _customerService.GetByDocumentNumber(documentNumber);

            if(customer is not null)
                return Ok(customer);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerRequest customerRequest)
        {
            var result = _customerService.Add(customerRequest);

            return Ok(result);
        }

        [HttpPut("{documentNumber}")]
        public IActionResult Put([FromRoute] string documentNumber, [FromBody] CustomerRequest customerRequest)
        {
            customerRequest.DocumentNumber = documentNumber;

            var result = _customerService.Update(customerRequest);

            return Ok(result);
        }
    }
}
