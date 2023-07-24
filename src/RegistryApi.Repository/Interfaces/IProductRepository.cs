using RegistryApi.Domain.Products.Data;
using RegistryApi.Domain.Request;

namespace RegistryApi.Repository.Interfaces;

public interface IProductRepository
{
    public List<ProductData> FindAll(PaginationRequest pagination);
    public ProductData FindById(string id);
    public ProductData Insert(ProductData productData);
    public ProductData Replace(ProductData productData);
    public bool Delete(string id);
    public bool Disable(string id, DateTime updatedAt);
}