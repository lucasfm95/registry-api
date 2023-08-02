namespace RegistryApi.Domain.Products.Request;

public class ProductPatchRequest
{
    public string? Branch { get; set; }
    public string? Model { get; set; }
    public string? Description { get; set; }
    public decimal Value { get; set; }
}