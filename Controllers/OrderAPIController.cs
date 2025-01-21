using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace OrderAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderAPIController : ControllerBase
    {
        private readonly ILogger<OrderAPIController> _logger;

        public OrderAPIController(ILogger<OrderAPIController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GET/Api/Orders")]
        public OrderClass Orders()
        {
            var file_path = "../Storage/orders.json";
            var json = File.ReadAllText(file_path);
            var options = new JsonSerializerOptions { IncludeFields = true };
            var orders = JsonSerializer.Deserialize<OrderClass>(json, options);
            Console.WriteLine(orders);

            OrderClass order = new OrderClass() {
                Id = 1,
                customer_name = "iksan",
                product_name = "samsung",
                quantity = 1,
                total_price = 0,
                order_date = DateOnly.FromDateTime(DateTime.Now),
                shipping_address = "Jawa barat",
                status = "pending"
            };
            return order;
        }

        [HttpPost(Name = "POST/Api/Orders")]
        public String post(IFormCollection collection)
        {
            var file_path = "../Storage/orders.json";
            var options = new JsonSerializerOptions { IncludeFields = true };
            var orders = JsonSerializer.Serialize(collection, options);
            var json = File.WriteAllText(file_path, orders);

            return "Success post";
        }
    }
}
