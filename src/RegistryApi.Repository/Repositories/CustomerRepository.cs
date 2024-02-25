using MongoDB.Driver;
using RegistryApi.Domain.Customers.Data;
using RegistryApi.Domain.Request;
using RegistryApi.Repository.Factory;
using RegistryApi.Repository.Factory.Interfaces;
using RegistryApi.Repository.Repositories.Interfaces;

namespace RegistryApi.Repository.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoDatabase _database;

        public CustomerRepository(IMongoDbClientFactory mongoDbClientFactory)
        {
            _database = mongoDbClientFactory.GetDatabase(MongoDbSettings.ConnectionString, MongoDbSettings.DataBaseName);
        }

        public List<CustomerData> FindAll(PaginationRequest pagination)
        {
            try
            {
                pagination.Page--;
                var skip = pagination.Page * pagination.PerPage;
                var collection = _database.GetCollection<CustomerData>(MongoDbSettings.CustomersCollectionName);

                return collection.Find(Builders<CustomerData>.Filter.Empty).Skip(skip).Limit(pagination.PerPage).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CustomerData FindByDocumentNumber(string documentNumber)
        {
            try
            {
                var collection = _database.GetCollection<CustomerData>(MongoDbSettings.CustomersCollectionName);

                var result = collection.Find(customer => customer.DocumentNumber == documentNumber);

                return result.FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CustomerData Insert(CustomerData customerData)
        {
            try
            {
                var collection = _database.GetCollection<CustomerData>(MongoDbSettings.CustomersCollectionName);

                collection.InsertOne(customerData);

                return customerData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public CustomerData Replace(CustomerData customerData)
        {
            try
            {
                var customer = FindByDocumentNumber(customerData.DocumentNumber ?? "");

                var collection = _database.GetCollection<CustomerData>(MongoDbSettings.CustomersCollectionName);

                customerData.Id = customer.Id;
                customerData.CreatedAt = customer.CreatedAt;

                var result = collection.ReplaceOne(ctm => ctm.DocumentNumber == customerData.DocumentNumber, customerData);

                return customerData;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(CustomerData customerData)
        {
            try
            {
                var collection = _database.GetCollection<CustomerData>(MongoDbSettings.CustomersCollectionName);

                var filter = Builders<CustomerData>.Filter.Eq(customer => customer.DocumentNumber, customerData.DocumentNumber);

                var updateDefinitions = new List<UpdateDefinition<CustomerData>>();

                if (!string.IsNullOrEmpty(customerData.Name))
                {
                    updateDefinitions.Add(Builders<CustomerData>.Update.Set(customer => customer.Name, customerData.Name));
                }

                if (customerData.Enabled.HasValue)
                {
                    updateDefinitions.Add(Builders<CustomerData>.Update.Set(customer => customer.Enabled, customerData.Enabled ?? false));
                }

                updateDefinitions.Add(Builders<CustomerData>.Update.Set(customer => customer.UpdatedAt, customerData.UpdatedAt));

                var combinedUpdate = Builders<CustomerData>.Update.Combine(updateDefinitions);

                var result = collection.UpdateOne(filter, combinedUpdate);

                return result.ModifiedCount > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(string documentNumber)
        {
            try
            {
                var collection = _database.GetCollection<CustomerData>(MongoDbSettings.CustomersCollectionName);

                var result = collection.DeleteOne(customer => customer.DocumentNumber == documentNumber);

                return result.DeletedCount > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Disable(string documentNumber, DateTime updatedAt)
        {
            try
            {
                var collection = _database.GetCollection<CustomerData>(MongoDbSettings.CustomersCollectionName);

                var update = Builders<CustomerData>.Update.Set(customer => customer.Enabled, false)
                    .Set(customer => customer.UpdatedAt, updatedAt);
                var filter = Builders<CustomerData>.Filter.Eq(customer => customer.DocumentNumber, documentNumber);
                var options = new UpdateOptions { IsUpsert = true };

                var result = collection.UpdateOne(filter, update, options);

                return result.ModifiedCount > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
