using RegistryApi.Domain.Request;

namespace RegistryApi.Repository.Repositories.Interfaces;

public interface IRepository<T>
{
    public List<T> FindAll(PaginationRequest pagination);
    public T Insert(T entity);
    public T Replace(T entity);
    public bool Update(T entity);
    public bool Delete(T entity);
    public bool Disable(T entity, DateTime updatedAt);
}