using MongoDB.Driver;
using RegistryApi.Repository.Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryApi.Repository.Factory
{
    public class MongoDbClientFactory : IMongoDbClientFactory
    {
        public IMongoDatabase GetDatabase(string connectionString, string databaseName)
        {
            var mongoClient = new MongoClient(connectionString);

            return mongoClient.GetDatabase(databaseName);
        }
    }
}
