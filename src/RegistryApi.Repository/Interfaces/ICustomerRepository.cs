using RegistryApi.Domain.Customers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryApi.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        public List<CustomerData> FindAll();
    }
}
