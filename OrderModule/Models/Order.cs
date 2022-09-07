using Common.Models;

namespace OrderModule.Models
{
    public class Order : BaseEntity
    {
        public int OrderId { get; set; }
        public int Total { get; set; }
        public OrderStatus Status { get; set; }
    }
}
