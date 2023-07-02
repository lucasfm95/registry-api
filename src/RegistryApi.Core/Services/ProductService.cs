using RegistryApi.Core.Services.Interfaces;
using RegistryApi.Domain.Products.Request;
using RegistryApi.Domain.Products.Response;
using RegistryApi.Domain.Request;

namespace RegistryApi.Core.Services;

public class ProductService : IProductService
{
    public List<ProductResponse> GetAll(PaginationRequest pagination)
    {
        throw new NotImplementedException();
    }

    public ProductResponse Add(ProductPostRequest productPostRequest)
    {
        throw new NotImplementedException();
    }
}