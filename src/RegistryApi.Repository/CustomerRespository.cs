using RegistryApi.Domain.Customers.Data;
using RegistryApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryApi.Repository
{
    public class CustomerRespository : ICustomerRepository
    {
        public List<CustomerData> FindAll()
        {
            var customers = new List<CustomerData>();

            customers.Add(new CustomerData() { DocumentNumber = "09350460033", Name = "Harry Potter", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });
            customers.Add(new CustomerData() { DocumentNumber = "69054194006", Name = "Petter Parker", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });

            return customers;
        }
    }
}
