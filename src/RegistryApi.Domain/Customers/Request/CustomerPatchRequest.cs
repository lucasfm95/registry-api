using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RegistryApi.Domain.Customers.Request
{
    public class CustomerPatchRequest
    {
        [JsonIgnore]
        public string? DocumentNumber { get; set; }
        public string? Name { get; set; }
        public bool? Enabled { get; set; }
    }
}
