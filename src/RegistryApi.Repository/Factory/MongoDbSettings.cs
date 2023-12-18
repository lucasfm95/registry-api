using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryApi.Repository.Factory
{
    public static class MongoDbSettings
    {
        public static string ConnectionString { get => Environment.GetEnvironmentVariable("CONNECTION_STRING_MONGODB") ?? ""; }
        public static string DataBaseName { get => Environment.GetEnvironmentVariable("DATABASE_NAME") ?? ""; }
        public static string CustomersCollectionName { get => Environment.GetEnvironmentVariable("CUSTOMERS_COLLECTION_NAME") ?? ""; }
        public static string ProductsCollectionName { get => Environment.GetEnvironmentVariable("PRODUCT_COLLECTION_NAME") ?? ""; }
    }
}
