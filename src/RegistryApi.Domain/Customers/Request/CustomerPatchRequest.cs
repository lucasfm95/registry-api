﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RegistryApi.Domain.Customers.Request
{
    public class CustomerPatchRequest
    {
        [JsonIgnore]
        public string? DocumentNumber { get; set; }
        [StringLength(80, ErrorMessage = "The {0} field must be between {2} and {1} caracters long", MinimumLength = 3)]
        public string? Name { get; set; }
        public bool? Enabled { get; set; }
    }
}
