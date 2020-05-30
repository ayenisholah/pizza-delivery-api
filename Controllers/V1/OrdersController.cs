using System;
using System.Collections.Generic;
using DeliveryAPI.Contracts;
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
    }
}
