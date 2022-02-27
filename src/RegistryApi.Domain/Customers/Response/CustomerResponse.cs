using RegistryApi.Domain.Customers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryApi.Domain.Customers.Response
{
    public class CustomerResponse : CustomerData
    {
        public CustomerResponse()
        {
        }

        public CustomerResponse(CustomerData customerData)
        {
            this.DocumentNumber = customerData.DocumentNumber;
            this.Name = customerData.Name;
            this.CreatedAt = customerData.CreatedAt;
            this.UpdatedAt = customerData.UpdatedAt;
        }
    }
}
