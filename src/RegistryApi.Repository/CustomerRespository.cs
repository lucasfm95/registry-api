using MongoDB.Bson;
using MongoDB.Driver;
using RegistryApi.Domain.Customers.Data;
using RegistryApi.Repository.Factory;
using RegistryApi.Repository.Factory.Interfaces;
using RegistryApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryApi.Repository
{
    public class CustomerRespository : ICustomerRepository
    {
        private readonly IMongoDatabase _database;

        public CustomerRespository(IMongoDbClientFactory mongoDbClientFactory)
        {
            _database = mongoDbClientFactory.GetDatabase(MongoDbSettings.ConnectionString, MongoDbSettings.DataBaseName);
        }

        public List<CustomerData> FindAll()
        {
            try
            {
                var collection = _database.GetCollection<CustomerData>(MongoDbSettings.CustomersCollectionName);

                return collection.AsQueryable().ToList();
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

        public CustomerData Update(CustomerData customerData)
        {
            try
            {
                var customer = FindByDocumentNumber(customerData.DocumentNumber ?? "");

                var collection = _database.GetCollection<CustomerData>(MongoDbSettings.CustomersCollectionName);

                customerData.Id = customer.Id;
                customerData.CreatedAt = customer.CreatedAt;

                var result = collection.ReplaceOne(customer => customer.DocumentNumber == customerData.DocumentNumber, customerData);

                return customerData;
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
