using MongoDB.Driver;
using RegistryApi.Domain.Products.Data;
using RegistryApi.Domain.Request;
using RegistryApi.Repository.Factory;
using RegistryApi.Repository.Factory.Interfaces;
using RegistryApi.Repository.Interfaces;

namespace RegistryApi.Repository;

public class ProductRepository : IProductRepository
{
    private readonly IMongoDatabase _database;

    public ProductRepository(IMongoDbClientFactory mongoDbClientFactory)
    {
        _database = mongoDbClientFactory.GetDatabase(MongoDbSettings.ConnectionString, MongoDbSettings.DataBaseName);
    }

    public List<ProductData> FindAll(PaginationRequest pagination)
    {
        try
        {
            pagination.Page--;
            var skip = pagination.Page * pagination.PerPage;
            var collection = _database.GetCollection<ProductData>(MongoDbSettings.ProductsCollectionName);

            return collection.Find(Builders<ProductData>.Filter.Empty).Skip(skip).Limit(pagination.PerPage).ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public ProductData FindById(string id)
    {
        try
        {
            var collection = _database.GetCollection<ProductData>(MongoDbSettings.ProductsCollectionName);

            var result = collection.Find(productData => productData.Id == id);

            return result.FirstOrDefault();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public ProductData Insert(ProductData productData)
    {
        try
        {
            var collection = _database.GetCollection<ProductData>(MongoDbSettings.ProductsCollectionName);

            collection.InsertOne(productData);

            return productData;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public ProductData Replace(ProductData productData)
    {
        try
        {
            var product = FindById(productData.Id ?? "");

            var collection = _database.GetCollection<ProductData>(MongoDbSettings.ProductsCollectionName);

            productData.Id = product.Id;
            productData.CreatedAt = product.CreatedAt;

            var result = collection.ReplaceOne(pdt => pdt.Id == productData.Id, productData);

            return productData;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool Delete(string id)
    {
        try
        {
            var collection = _database.GetCollection<ProductData>(MongoDbSettings.ProductsCollectionName);

            var result = collection.DeleteOne(product => product.Id == id);

            return result.DeletedCount > 0;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool Disable(string id, DateTime updatedAt)
    {
        try
        {
            var collection = _database.GetCollection<ProductData>(MongoDbSettings.ProductsCollectionName);

            var update = Builders<ProductData>.Update.Set(product => product.Enabled, false)
                .Set(product => product.UpdatedAt, updatedAt);
            var filter = Builders<ProductData>.Filter.Eq(product => product.Id, id);
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