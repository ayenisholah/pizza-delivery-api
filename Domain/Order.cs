using System;
using System.ComponentModel.DataAnnotations;

namespace DeliveryAPI.Domain
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public decimal Amount { get; set; }
    }
}
