using RegistryApi.Core.Services.Interfaces;
using RegistryApi.Domain.Products.Data;
using RegistryApi.Domain.Products.Request;
using RegistryApi.Domain.Products.Response;
using RegistryApi.Domain.Request;
using RegistryApi.Repository.Interfaces;

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

    public ProductResponse Add(ProductPostRequest productPostRequest)
    {
        var productData = new ProductData(productPostRequest)
        {
            CreatedAt = DateTime.Now
        };
        productData.UpdatedAt = productData.CreatedAt;

        var result = _productRepository.Insert(productData);
        
        return new ProductResponse(result);
    }
}