using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cosmonaut;
using Cosmonaut.Extensions;
using DeliveryAPI.Domain;

namespace DeliveryAPI.Services
{
    public class CosmosOrderService : IOrderService
    {
        private readonly ICosmosStore<CosmosOrderDto> _cosmosStore;

        public CosmosOrderService(ICosmosStore<CosmosOrderDto> cosmosStore)
        {
            _cosmosStore = cosmosStore;
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            var cosmosOrder = new CosmosOrderDto
            {
                Id = Guid.NewGuid().ToString(),
                Amount = order.Amount
            };

            var response = await _cosmosStore.AddAsync(cosmosOrder);
            order.Id = Guid.Parse(cosmosOrder.Id);
            return response.IsSuccess;
        }

        public async Task<bool> DeleteOrderAsync(Guid orderId)
        {
            var response = await _cosmosStore.RemoveByIdAsync(orderId.ToString(), orderId.ToString());
            return response.IsSuccess;
        }

        public async Task<Order> GetOrderByIdAsync(Guid orderId)
        {
            var order = await _cosmosStore.FindAsync(orderId.ToString(), orderId.ToString());

            return order == null ? null : new Order { Id = Guid.Parse(order.Id), Amount = order.Amount };
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            var orders = await _cosmosStore.Query().ToListAsync();

            return orders.Select(x => new Order { Id = Guid.Parse(x.Id), Amount = x.Amount }).ToList();
        }

        public async Task<bool> UpdateOrderAsync(Order orderToUpdate)
        {
            var cosmosOrder = new CosmosOrderDto
            {
                Id = orderToUpdate.Id.ToString(),
                Amount = orderToUpdate.Amount
            };

            var response = await _cosmosStore.UpdateAsync(cosmosOrder);
            return response.IsSuccess;
        }

        public Task<bool> UserOwnsOrderAsync(Guid orderId, string v)
        {
            throw new NotImplementedException();
        }
    }
}
