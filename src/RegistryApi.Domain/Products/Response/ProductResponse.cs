using RegistryApi.Domain.Products.Data;

namespace RegistryApi.Domain.Products.Response;

public class ProductResponse
{
    public string? Branch { get; set; }
    public string? Model { get; set; }
    public string? Description { get; set; }
    public decimal Value { get; set; }
    public bool? Enabled { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ProductResponse() { }
    
    public ProductResponse(ProductData productData)
    {
        Branch = productData.Branch;
        Model = productData.Model;
        Description = productData.Description;
        Value = productData.Value;
        Enabled = productData.Enabled;
        CreatedAt = productData.CreatedAt;
        UpdatedAt = productData.UpdatedAt;
    }
}