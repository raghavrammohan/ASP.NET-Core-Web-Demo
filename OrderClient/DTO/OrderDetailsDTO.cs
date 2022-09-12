namespace OrderClient.DTO
{
    public class OrderDetailsDTO
    {
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
