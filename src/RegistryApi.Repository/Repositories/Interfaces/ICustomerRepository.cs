﻿using RegistryApi.Domain.Customers.Data;
using RegistryApi.Domain.Request;

namespace RegistryApi.Repository.Repositories.Interfaces;

public interface ICustomerRepository
{
    public List<CustomerData> FindAll(PaginationRequest pagination);
    public CustomerData FindByDocumentNumber(string documentNumber);
    public CustomerData Insert(CustomerData customerData);
    public CustomerData Replace(CustomerData customerData);
    public bool Update(CustomerData customerData);
    public bool Delete(string documentNumber);
    public bool Disable(string documentNumber, DateTime updatedAt);
}

