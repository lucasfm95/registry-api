using RegistryApi.Core.Services.Interfaces;
using RegistryApi.Domain.Customers.Data;
using RegistryApi.Domain.Customers.Request;
using RegistryApi.Domain.Customers.Response;
using RegistryApi.Domain.Request;
using RegistryApi.Repository;
using RegistryApi.Repository.Interfaces;
using System.Text.Json;

namespace RegistryApi.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public List<string> ErrorsMessages { get; set; }

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            ErrorsMessages = new List<string>();
        }
        public List<CustomerResponse> GetAll(PaginationRequest pagination)
        {
            var sqlServerRepository = new CustomerSqlRepository();

            var customersData = sqlServerRepository.FindAll(pagination);

            customersData.AddRange(_customerRepository.FindAll(pagination));

            return customersData.Select(customer => new CustomerResponse(customer)).ToList();
        }

        public CustomerResponse? GetByDocumentNumber(string documentNumber)
        {
            var customerData = _customerRepository.FindByDocumentNumber(documentNumber);

            if (customerData is not null)
                return new CustomerResponse(customerData);
            return null;
        }

        public CustomerResponse? Add(CustomerPostRequest customerRequest)
        {
            var customerData = new CustomerData(customerRequest);

            customerData.CreatedAt = DateTime.Now;
            customerData.UpdatedAt = customerData.CreatedAt;

            var result = _customerRepository.Insert(customerData);

            if (result is not null)
                return new CustomerResponse(result);

            ErrorsMessages.Add($"Error to insert the customer -> { JsonSerializer.Serialize(customerData) }");
            return null;
        }

        public CustomerResponse? Replace(CustomerPutRequest customerRequest)
        {
            var customerData = new CustomerData(customerRequest);

            customerData.UpdatedAt = DateTime.Now;

            var result = _customerRepository.Replace(customerData);

            if (result is not null)
                return new CustomerResponse(result);

            ErrorsMessages.Add($"Error to replace the customer -> {JsonSerializer.Serialize(customerData)}");
            return null;
        }

        public bool Update(CustomerPatchRequest customerRequest)
        {
            var customerData = new CustomerData(customerRequest);

            customerData.UpdatedAt = DateTime.Now;

            var result = _customerRepository.Update(customerData);

            return result;
        }

        public bool Delete(string documentNumber)
        {
            var result = _customerRepository.Delete(documentNumber);

            return result;
        }

        public bool Disable(string documentNumber)
        {
            var result = _customerRepository.Disable(documentNumber, DateTime.Now);

            return result;
        }

        public bool ValidateDuplicateDocumentNumber(string documentNumber)
        {
            var customer = GetByDocumentNumber(documentNumber);
            if (customer is null)
                return false;

            ErrorsMessages.Add($"Document number {documentNumber} is duplicated");
            return true;
        }

        public bool ValidatePatchUpdate(CustomerPatchRequest customer)
        {
            if(customer.Name is not null || customer.Enabled is not null)
                return true;

            ErrorsMessages.Add("Name or enabled field is required");
            return false;
        }
    }
}
