using OrderClient.DTO;
using OrderModule.Models;

namespace OrderModule.Services
{
    public interface IOrderService
    {
        public OrderDTO GetOrderDetails(string orderId);
        public OrderDTO CreateOrder(OrderDTO orderDTO);
        public void DeleteOrder(string orderId);
    }
}
