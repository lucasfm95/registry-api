using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RegistryApi.Domain.Customers.Request;
using System.Text.Json.Serialization;

namespace RegistryApi.Domain.Customers.Data
{
    public class CustomerData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [JsonIgnore]
        public string? Id { get; set; }
        public string? DocumentNumber { get; set; }
        public string? Name { get; set; }
        public bool? Enabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        protected CustomerData()
        {

        }

        public CustomerData(CustomerPostRequest customerRequest)
        {
            DocumentNumber = customerRequest.DocumentNumber;
            Name = customerRequest.Name;
            Enabled = customerRequest.Enabled.HasValue ? customerRequest.Enabled.Value : true;
        }

        public CustomerData(CustomerPutRequest customerRequest)
        {
            DocumentNumber = customerRequest.DocumentNumber;
            Name = customerRequest.Name;
            Enabled = customerRequest.Enabled.HasValue ? customerRequest.Enabled.Value : false;
        }

        public CustomerData(CustomerPatchRequest customerRequest)
        {
            DocumentNumber = customerRequest.DocumentNumber;
            Name = customerRequest.Name;
            Enabled = customerRequest.Enabled;
        }
    }
}
