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

        public CustomerResponse Add(CustomerRequest customerRequest)
        {
            var customerData = new CustomerData(customerRequest);

            var result = _customerRepository.Insert(customerData);

            return new CustomerResponse(result);
        }

        public CustomerResponse Update(CustomerRequest customerRequest)
        {
            var customerData = new CustomerData(customerRequest);

            var result = _customerRepository.Update(customerData);

            return new CustomerResponse(result);
        }
    }
}
