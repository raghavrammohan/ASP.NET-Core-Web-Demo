namespace ProductClient.DTO;

public record ProductDTO
{
    public string ProductId { get; set; }
    public string ExternalProductId { get; set; }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string CustomsDescription { get; set; }
}