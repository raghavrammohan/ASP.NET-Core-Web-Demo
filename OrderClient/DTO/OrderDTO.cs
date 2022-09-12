using OrderModule.Models;

namespace OrderClient.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int Total { get; set; }
        public OrderStatus Status { get; set; }
    }
}
