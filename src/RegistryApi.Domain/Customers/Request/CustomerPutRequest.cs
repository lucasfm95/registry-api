using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RegistryApi.Domain.Customers.Request
{
    public class CustomerPutRequest
    {
        [JsonIgnore]
        public string? DocumentNumber { get; set; }
        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(80, ErrorMessage = "The {0} field must be between {2} and {1} caracters long", MinimumLength = 3)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "The {0} field is required")]
        public bool? Enabled { get; set; }
    }
}
