using OrderClient.DTO;

namespace OrderModule.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderService _orderService;

        public OrderService(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public OrderDTO CreateOrder(OrderDTO orderDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(string orderId)
        {
            throw new NotImplementedException();
        }

        public OrderDTO GetOrderDetails(string orderId)
        {
            throw new NotImplementedException();
        }
    }
}
