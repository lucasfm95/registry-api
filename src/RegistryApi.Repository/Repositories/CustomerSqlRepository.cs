using RegistryApi.Domain.Customers.Data;
using RegistryApi.Domain.Request;
using RegistryApi.Repository.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace RegistryApi.Repository;

public class CustomerSqlRepository : ICustomerRepository
{
    public bool Delete(string documentNumber)
    {
        throw new NotImplementedException();
    }

    public bool Disable(string documentNumber, DateTime updatedAt)
    {
        throw new NotImplementedException();
    }

    public List<CustomerData> FindAll(PaginationRequest pagination)
    {
        using SqlConnection connection = new SqlConnection(SqlServerSettings.ConnectionString);
        return connection.Query<CustomerData>("SELECT * from customers").ToList();
    }

    public CustomerData FindByDocumentNumber(string documentNumber)
    {
        throw new NotImplementedException();
    }

    public CustomerData Insert(CustomerData customerData)
    {
        throw new NotImplementedException();
    }

    public CustomerData Replace(CustomerData customerData)
    {
        throw new NotImplementedException();
    }

    public bool Update(CustomerData customerData)
    {
        throw new NotImplementedException();
    }
}
