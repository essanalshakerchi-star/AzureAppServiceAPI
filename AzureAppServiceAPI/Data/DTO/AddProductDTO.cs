namespace AzureAppServiceAPI.Data.DTO
{
    public class AddProductDTO
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
