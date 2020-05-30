using System;
using System.Collections.Generic;
using DeliveryAPI.Contracts;
using DeliveryAPI.Contracts.V1.Requests;
using DeliveryAPI.Contracts.V1.Responses;
using DeliveryAPI.Domain;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryAPI.Controllers
{
    public class OrdersController : Controller
    {

        private List<Order> _orders;
        public OrdersController()
        {
            _orders = new List<Order>();

            for (var i = 0; i < 5; i++)
            {
                _orders.Add(new Order { Id = Guid.NewGuid().ToString() });
            }
        }

        [HttpGet(ApiRoutes.Orders.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_orders);
        }

        [HttpPost(ApiRoutes.Orders.Create)]
        public IActionResult Create([FromBody] CreateOrderRequest orderRequest)
        {
            var order = new Order { Id = orderRequest.Id };

            if (string.IsNullOrEmpty(order.Id))
                order.Id = Guid.NewGuid().ToString();

            _orders.Add(order);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Orders.Get.Replace("{orderId}", order.Id);

            var response = new OrderResponse { Id = order.Id };
            return Created(locationUri, response);
        }

    }
}
