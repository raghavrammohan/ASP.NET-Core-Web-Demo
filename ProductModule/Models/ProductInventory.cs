using Common.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductModule.Models
{
    [Table("product_inventory")]
    public class ProductInventory : BaseEntity
    {
        [Key] public string ProductInventoryId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
