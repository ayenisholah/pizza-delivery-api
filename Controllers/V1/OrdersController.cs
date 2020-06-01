using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderService.GetOrdersAsync());
        }

        [HttpPut(ApiRoutes.Orders.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid orderId, [FromBody] UpdateOrderRequest request)
        {
            var order = new Order
            {
                Id = orderId,
                Amount = request.Amount
            };

            var updated = await _orderService.UpdateOrderAsync(order);

            if (updated) return Ok(order);

            return NotFound();

        }

        [HttpGet(ApiRoutes.Orders.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);

            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPost(ApiRoutes.Orders.Create)]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest orderRequest)
        {
            var order = new Order { Amount = orderRequest.Amount };

            await _orderService.CreateOrderAsync(order);
            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Orders.Get.Replace("{orderId}", order.Id.ToString());

            var response = new OrderResponse { Id = order.Id };
            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoutes.Orders.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid orderId)
        {
            var deleted = await _orderService.DeleteOrderAsync(orderId);

            if (deleted) return NoContent();

            return NotFound();
        }

    }
}
