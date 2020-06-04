using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace DeliveryAPI.Domain
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public decimal Amount { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }
    }
}
