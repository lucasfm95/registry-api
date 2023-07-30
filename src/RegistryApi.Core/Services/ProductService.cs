using RegistryApi.Core.Services.Interfaces;
using RegistryApi.Domain.Products.Data;
using RegistryApi.Domain.Products.Request;
using RegistryApi.Domain.Products.Response;
using RegistryApi.Domain.Request;
using RegistryApi.Repository.Repositories.Interfaces;

namespace RegistryApi.Core.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<ProductResponse> GetAll(PaginationRequest pagination)
    {
        var result = _productRepository.FindAll(pagination);
        
        return result.Select(product => new ProductResponse(product)).ToList();
    }

    public ProductResponse? GetByCode(int code)
    {
        var product = _productRepository.FindByCode(code);

        if (product is null)
        {
            return null;
        }
        
        return new ProductResponse(product);
    }

    public ProductResponse Add(ProductPostRequest productPostRequest)
    {
        var productData = new ProductData(productPostRequest)
        {
            CreatedAt = DateTime.Now,
            Code = 0
        };
        productData.UpdatedAt = productData.CreatedAt;

        var lastCodeInserted = _productRepository.LastCodeInserted();

        productData.Code = lastCodeInserted + 1;

        var productOnDatabase = _productRepository.FindByCode(productData.Code);

        if (productOnDatabase is not null)
        {
            throw new Exception($"The code [{productData.Code}] already exists");
        }

        var result = _productRepository.Insert(productData);
        
        return new ProductResponse(result);
    }
}