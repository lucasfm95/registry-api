using RegistryApi.Domain.Customers.Request;
using RegistryApi.Domain.Customers.Response;
using RegistryApi.Domain.Request;

namespace RegistryApi.Core.Services.Interfaces
{
    public interface ICustomerService
    {
        public List<string> ErrorsMessages { get; set; }
        public List<CustomerResponse> GetAll(PaginationRequest pagination);
        public CustomerResponse? GetByDocumentNumber(string documentNumber);
        public CustomerResponse? Add(CustomerPostRequest customerRequest);
        public CustomerResponse? Replace(CustomerPutRequest customerRequest);
        public bool Update(CustomerPatchRequest customerRequest);
        public bool Delete(string documentNumber);
        public bool Disable(string documentNumber);
        public bool ValidateDuplicateDocumentNumber(string documentNumber);
        public bool ValidatePatchUpdate(CustomerPatchRequest customer);
    }
}
