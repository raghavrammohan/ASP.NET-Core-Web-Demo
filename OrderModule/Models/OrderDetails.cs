using Common.Models;

namespace OrderModule.Models
{
    public class OrderDetails : BaseEntity
    {
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
