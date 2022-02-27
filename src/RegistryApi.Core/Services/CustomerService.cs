using RegistryApi.Core.Services.Interfaces;
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
        public List<CustomerResponse> FindAll()
        {
            var customers = _customerRepository.FindAll();

            return customers.Select(customer => new CustomerResponse(customer)).ToList();
        }
    }
}
