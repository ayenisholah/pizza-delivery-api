using System;
using System.Collections.Generic;
using DeliveryAPI.Domain;

namespace DeliveryAPI.Services
{
    public interface IOrderService
    {
        List<Order> GetOrder();

        Order GetOrderById(Guid orderId);

        bool UpdateOrder(Order orderToUpdate);
    }
}
