using RegistryApi.Domain.Products.Request;

namespace RegistryApi.Domain.Products.Data;

public class ProductData
{
    public int Id { get; set; }
    public string? Branch { get; set; }
    public string? Model { get; set; }
    public string? Description { get; set; }
    public decimal Value { get; set; }
    public bool? Enabled { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ProductData() { }
    public ProductData(ProductPostRequest productPostRequest)
    {
        Branch = productPostRequest.Branch;
        Model = productPostRequest.Model;
        Description = productPostRequest.Description;
        Value = productPostRequest.Value;
        Enabled = productPostRequest.Enabled;
    }
}