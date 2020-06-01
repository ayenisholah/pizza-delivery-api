using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeliveryAPI.Domain;

namespace DeliveryAPI.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersAsync();

        Task<bool> CreateOrderAsync(Order order);

        Task<Order> GetOrderByIdAsync(Guid orderId);

        Task<bool> UpdateOrderAsync(Order orderToUpdate);

        Task<bool> DeleteOrderAsync(Guid orderId);
    }
}
