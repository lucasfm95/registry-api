using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegistryApi.Core.Services.Interfaces;
using RegistryApi.Domain.Customers.Requests;
using RegistryApi.Domain.Request;
using RegistryApi.Domain.Response;
using System.Net;

namespace RegistryApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] PaginationRequest pagination)
        {
            var customers = _customerService.GetAll(pagination);

            return Ok(customers);
        }

        [HttpGet("{documentNumber}")]
        public IActionResult GetByDocumentNumber([FromRoute] string documentNumber)
        {
            var customer = _customerService.GetByDocumentNumber(documentNumber);

            if (customer is not null)
                return Ok(customer);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerPostRequest customerRequest)
        {
            if (_customerService.ValideteDuplicateDocumentNumber(customerRequest.DocumentNumber ?? ""))
                return BadRequest(new ErrorResponse
                { StatusCode = HttpStatusCode.BadRequest, Description = "value duplicated", ErrorsMessages = _customerService.ErrorsMessages });

            var result = _customerService.Add(customerRequest);

            if (result is not null)
                return Ok(result);
            return BadRequest(new ErrorResponse { StatusCode = HttpStatusCode.BadRequest, Description = "Error to insert customer", ErrorsMessages = _customerService.ErrorsMessages });
        }

        [HttpPut("{documentNumber}")]
        public IActionResult Put([FromRoute] string documentNumber, [FromBody] CustomerPutRequest customerRequest)
        {
            customerRequest.DocumentNumber = documentNumber;

            var result = _customerService.Replace(customerRequest);

            if (result is not null)
                return Ok(result);
            return BadRequest(new ErrorResponse { StatusCode = HttpStatusCode.BadRequest, Description = "Error to update customer", ErrorsMessages = _customerService.ErrorsMessages });
        }

        [HttpPatch("{documentNumber}")]
        public IActionResult Patch([FromRoute] string documentNumber, [FromBody] CustomerPatchRequest customerRequest)
        {
            if (!_customerService.ValidatePatchUpdate(customerRequest))
                return BadRequest(new ErrorResponse { StatusCode = HttpStatusCode.BadRequest, Description = "The field is required", ErrorsMessages = _customerService.ErrorsMessages });
            customerRequest.DocumentNumber = documentNumber;
            var result = _customerService.Update(customerRequest);

            if (result)
                return Ok();
            return BadRequest(new ErrorResponse { StatusCode = HttpStatusCode.BadRequest, Description = "Error to update customer" });
        }

        [HttpDelete("{documentNumber}")]
        public IActionResult Delete([FromRoute] string documentNumber)
        {
            var result = _customerService.Delete(documentNumber);

            if (result)
                return Ok();
            return BadRequest(new ErrorResponse { StatusCode = HttpStatusCode.BadRequest, Description = "Error to delete customer" });
        }

        [HttpPatch("Disable/{documentNumber}")]
        public IActionResult Disable([FromRoute] string documentNumber)
        {
            var result = _customerService.Disable(documentNumber);

            if (result)
                return Ok();
            return BadRequest(new ErrorResponse { StatusCode = HttpStatusCode.BadRequest, Description = "Error to disable customer" });
        }
    }
}
