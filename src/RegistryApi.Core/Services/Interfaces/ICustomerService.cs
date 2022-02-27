using RegistryApi.Domain.Customers.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryApi.Core.Services.Interfaces
{
    public interface ICustomerService
    {
        public List<CustomerResponse> FindAll(); 
    }
}
