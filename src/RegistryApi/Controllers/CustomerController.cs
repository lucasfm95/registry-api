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
        public IActionResult Post([FromBody] CustomerPostRequest customerRequest)
        {
            var customer = _customerService.GetByDocumentNumber(customerRequest.DocumentNumber ?? "");

            if (customer is not null)
                return BadRequest(new { errorMessage = $"documentNumber {customer?.DocumentNumber} already exists" });

            var result = _customerService.Add(customerRequest);

            return Ok(result);
        }

        [HttpPut("{documentNumber}")]
        public IActionResult Put([FromRoute] string documentNumber, [FromBody] CustomerPutRequest customerRequest)
        {
            customerRequest.DocumentNumber = documentNumber;

            var result = _customerService.Update(customerRequest);

            return Ok(result);
        }

        [HttpDelete("{documentNumber}")]
        public IActionResult Delete([FromRoute] string documentNumber)
        {
            var result = _customerService.Delete(documentNumber);

            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpPatch("Disable/{documentNumber}")]
        public IActionResult Disable([FromRoute] string documentNumber)
        {
            var result = _customerService.Disable(documentNumber);

            if (result)
                return Ok();
            return BadRequest();
        }
    }
}
