using RegistryApi.Domain.Products.Request;
using RegistryApi.Domain.Products.Response;
using RegistryApi.Domain.Request;

namespace RegistryApi.Core.Services.Interfaces;

public interface IProductService
{
    public List<ProductResponse> GetAll(PaginationRequest pagination);
    public ProductResponse Add(ProductPostRequest productPostRequest);
}