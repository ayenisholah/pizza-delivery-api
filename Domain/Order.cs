using System;
namespace DeliveryAPI.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
    }
}
