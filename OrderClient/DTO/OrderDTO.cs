using OrderModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderClient.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int Total { get; set; }
        public OrderStatus Status { get; set; }
    }
}
