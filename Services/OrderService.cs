using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryAPI.Data;
using DeliveryAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeliveryAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _dataContext;

        public OrderService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            await _dataContext.Orders.AddAsync(order);
            var created = await _dataContext.SaveChangesAsync();

            return created > 0;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _dataContext.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(Guid orderId)
        {
            return await _dataContext.Orders.SingleOrDefaultAsync(x => x.Id == orderId);
        }

        public async Task<bool> UpdateOrderAsync(Order orderToUpdate)
        {
            _dataContext.Orders.Update(orderToUpdate);
            var updated = await _dataContext.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteOrderAsync(Guid orderId)
        {
            var order = await GetOrderByIdAsync(orderId);
            _dataContext.Orders.Remove(order);

            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}