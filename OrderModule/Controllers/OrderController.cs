using Microsoft.AspNetCore.Mvc;
using OrderModule.Services;

namespace OrderModule.Controllers
{
    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("/getOrderDetails")]
        public IActionResult getOrder(string orderId)
        {
            return NoContent();
        }

        [HttpPost("/createOrder")]
        public IActionResult createOrder()
        {
            return NoContent();
        }

        [HttpDelete("/deleteOrder")]
        public IActionResult deleteOrder(string orderId)
        {
            return NoContent();
        }


    }
}
