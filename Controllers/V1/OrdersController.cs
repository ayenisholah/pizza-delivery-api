using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryAPI.Contracts;
using DeliveryAPI.Contracts.V1.Requests;
using DeliveryAPI.Contracts.V1.Responses;
using DeliveryAPI.Domain;
using DeliveryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryAPI.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;


        }

        [HttpGet(ApiRoutes.Orders.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_orderService.GetOrder());
        }

        [HttpPut(ApiRoutes.Orders.Update)]
        public IActionResult Update([FromRoute] Guid orderId, [FromBody] UpdateOrderRequest request)
        {
            var order = new Order
            {
                Id = orderId,
                Amount = request.Amount
            };

            var updated = _orderService.UpdateOrder(order);

            if (updated) return Ok(order);

            return NotFound();

        }

        [HttpGet(ApiRoutes.Orders.Get)]
        public IActionResult Get([FromRoute] Guid orderId)
        {
            var order = _orderService.GetOrderById(orderId);

            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost(ApiRoutes.Orders.Create)]
        public IActionResult Create([FromBody] CreateOrderRequest orderRequest)
        {
            var order = new Order { Id = orderRequest.Id };

            if (order.Id != Guid.Empty)
                order.Id = Guid.NewGuid();

            _orderService.GetOrder().Add(order);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Orders.Get.Replace("{orderId}", order.Id.ToString());

            var response = new OrderResponse { Id = order.Id };
            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoutes.Orders.Delete)]
        public IActionResult Delete([FromRoute] Guid orderId)
        {
            var deleted = _orderService.DeleteOrder(orderId);

            if (deleted) return NoContent();

            return NotFound();
        }

    }
}
