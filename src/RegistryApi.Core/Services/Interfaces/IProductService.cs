using RegistryApi.Domain.Products.Request;
using RegistryApi.Domain.Products.Response;
using RegistryApi.Domain.Request;

namespace RegistryApi.Core.Services.Interfaces;

public interface IProductService
{
    public List<ProductResponse> GetAll(PaginationRequest pagination);
    public ProductResponse? GetByCode(int code);
    public ProductResponse Add(ProductPostRequest productPostRequest);
    public ProductResponse Replace(ProductPutRequest productPutRequest);
    public ProductResponse Update(ProductPatchRequest productPatchRequest);
    public bool Delete(int code);
    public bool Disable(int code);
}