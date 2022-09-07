using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductClient.DTO
{
    public class ProductInventoryDTO
    {
        public string ProductInventoryId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
