using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RegistryApi.Domain.Customers.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RegistryApi.Domain.Customers.Data
{
    public class CustomerData
    {
        public CustomerData()
        {

        }

        public CustomerData(CustomerRequest customerRequest)
        {
            DocumentNumber = customerRequest.DocumentNumber;
            Name = customerRequest.Name;
            CreatedAt = customerRequest.CreatedAt;
            UpdatedAt = customerRequest.UpdatedAt;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string? Id { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
