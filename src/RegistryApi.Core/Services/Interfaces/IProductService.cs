using RegistryApi.Domain.Products.Request;

namespace RegistryApi.Core.Services.Interfaces;

public interface IProductService
{
    public void Add(ProductPostRequest productPostRequest);
}