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
            var collection = _database.GetCollection<CustomerData>(MongoDbSettings.CustomersCollectionName);

            var result = collection.ReplaceOne(customer => customer.DocumentNumber == customerData.DocumentNumber, customerData);

            return customerData;
        }
    }
}
