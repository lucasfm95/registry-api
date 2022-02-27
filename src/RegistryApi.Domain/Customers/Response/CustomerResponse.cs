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
            DocumentNumber = customerData.DocumentNumber;
            Name = customerData.Name;
            CreatedAt = customerData.CreatedAt;
            UpdatedAt = customerData.UpdatedAt;
        }
    }
}
