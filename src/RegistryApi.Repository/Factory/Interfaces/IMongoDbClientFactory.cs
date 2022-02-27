using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryApi.Repository.Factory.Interfaces
{
    public interface IMongoDbClientFactory
    {
        IMongoDatabase GetDatabase(string connectionString, string databaseName);
    }
}
