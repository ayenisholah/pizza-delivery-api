using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryAPI.Domain;

namespace DeliveryAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly List<Order> _orders;


        public OrderService()
        {
            _orders = new List<Order>();

            for (var i = 0; i < 5; i++)
            {
                _orders.Add(new Order
                {
                    Id = Guid.NewGuid(),
                    Amount = 9.99M
                });
            }
        }

        public List<Order> GetOrder()
        {
            return _orders;
        }

        public Order GetOrderById(Guid orderId)
        {
            return _orders.SingleOrDefault(x => x.Id == orderId);
        }

        public bool UpdateOrder(Order orderToUpdate)
        {
            var orderExists = GetOrderById(orderToUpdate.Id) != null;

            if (!orderExists) return false;

            var index = _orders.FindIndex(x => x.Id == orderToUpdate.Id);
            _orders[index] = orderToUpdate;

            return true;
        }
    }
}