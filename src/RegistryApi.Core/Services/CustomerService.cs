using RegistryApi.Core.Services.Interfaces;
using RegistryApi.Domain.Customers.Data;
using RegistryApi.Domain.Customers.Request;
using RegistryApi.Domain.Customers.Response;
using RegistryApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryApi.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public List<CustomerResponse> GetAll()
        {
            var customersData = _customerRepository.FindAll();

            return customersData.Select(customer => new CustomerResponse(customer)).ToList();
        }

        public CustomerResponse? GetByDocumentNumber(string documentNumber)
        {
            var customerData = _customerRepository.FindByDocumentNumber(documentNumber);

            if (customerData is not null)
                return new CustomerResponse(customerData);
            return null;
        }

        public CustomerResponse Add(CustomerPostRequest customerRequest)
        {
            var customerData = new CustomerData(customerRequest);

            customerData.CreatedAt = DateTime.Now;
            customerData.UpdatedAt = customerData.CreatedAt;

            var result = _customerRepository.Insert(customerData);

            return new CustomerResponse(result);
        }

        public CustomerResponse Replace(CustomerPutRequest customerRequest)
        {
            var customerData = new CustomerData(customerRequest);

            customerData.UpdatedAt = DateTime.Now;

            var result = _customerRepository.Replace(customerData);

            return new CustomerResponse(result);
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

        public bool ValidatePatchUpdate(CustomerPatchRequest customer)
        {
            return (customer.Name is not null || customer.Enabled is not null);
        }
    }
}
