namespace RegistryApi.Domain.Products.Request
{
	public class ProductPostRequest
	{
		public int Id { get; set; }
		public string? Branch { get; set; }
		public string? Model { get; set; }
		public string? Description { get; set; }
		public decimal Value { get; set; }
        public bool? Enabled { get; set; }
    }
}

