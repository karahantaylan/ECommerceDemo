
using ECommerce.Service.Infrastructure;
using ECommerce.Service.DataService;
using ECommerce.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ECommerce.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _orderRepository;

        public OrderController(IOrder orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET api/order
        [HttpGet]
        public IEnumerable<OrderModel> Get()
        {
            return _orderRepository.GetAll();
        }

        // GET order/2
        [HttpGet("{orderId}", Name = "GetOrder")]
        public IActionResult Get(int orderId)
        {
            var order = _orderRepository.GetByOrderId(orderId);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST order
        [HttpPost]
        public ContentResult Post([FromBody]OrderModel value)
        {
            if (value == null)
            {
                return Content("Bad Request");
            }
            
            _orderRepository.Add(value);

            return Content("Order has created.");
        }
    }
}
