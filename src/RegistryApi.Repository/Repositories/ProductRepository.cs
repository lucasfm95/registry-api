using MongoDB.Driver;
using RegistryApi.Domain.Products.Data;
using RegistryApi.Domain.Request;
using RegistryApi.Repository.Factory;
using RegistryApi.Repository.Factory.Interfaces;
using RegistryApi.Repository.Repositories.Interfaces;

namespace RegistryApi.Repository.Repositories;

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
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
    public ProductData? FindByCode(int code)
    {
        try
        {
            var collection = _database.GetCollection<ProductData>(MongoDbSettings.ProductsCollectionName);

            var result = collection.Find(product => product.Code == code);

            return result.FirstOrDefault();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public int LastCodeInserted()
    {
        try
        {
            var collection = _database.GetCollection<ProductData>(MongoDbSettings.ProductsCollectionName);

            var lastProduct = collection.AsQueryable().OrderByDescending(c => c.CreatedAt).FirstOrDefault();

            if (lastProduct is null)
            {
                return 0;
            }

            return lastProduct.Code;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
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
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public ProductData Replace(ProductData productData)
    {
        try
        {
            var product = FindByCode(productData.Code);

            var collection = _database.GetCollection<ProductData>(MongoDbSettings.ProductsCollectionName);

            productData.Id = product?.Id;
            productData.Code = product?.Code ?? 0;
            productData.CreatedAt = product?.CreatedAt ?? DateTime.Now;

            collection.ReplaceOne(pdt => pdt.Code == productData.Code, productData);

            return productData;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public bool Update(ProductData productData)
    {
        throw new NotImplementedException();
    }

    public bool Delete(int code)
    {
        try
        {
            var collection = _database.GetCollection<ProductData>(MongoDbSettings.ProductsCollectionName);
        
            var result = collection.DeleteOne(product => product.Code == code);
        
            return result.DeletedCount > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public bool Disable(int code, DateTime updatedAt)
    {
        try
        {
            var collection = _database.GetCollection<ProductData>(MongoDbSettings.ProductsCollectionName);
        
            var update = Builders<ProductData>.Update.Set(product => product.Enabled, false)
                .Set(product => product.UpdatedAt, updatedAt);
            var filter = Builders<ProductData>.Filter.Eq(product => product.Code, code);
            var options = new UpdateOptions { IsUpsert = true };
        
            var result = collection.UpdateOne(filter, update, options);
        
            return result.ModifiedCount > 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}