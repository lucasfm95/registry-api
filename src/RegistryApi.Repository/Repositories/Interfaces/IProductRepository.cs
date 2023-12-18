using RegistryApi.Domain.Products.Data;
using RegistryApi.Domain.Request;

namespace RegistryApi.Repository.Repositories.Interfaces;

public interface IProductRepository
{
    public List<ProductData> FindAll(PaginationRequest pagination);
    public ProductData? FindByCode(int code);
    public int LastCodeInserted();
    public ProductData Insert(ProductData productData);
    public ProductData Replace(ProductData productData);
    public bool Update(ProductData productData);
    public bool Delete(int code);
    public bool Disable(int code, DateTime updatedAt);
}