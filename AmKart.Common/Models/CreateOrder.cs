using System;
using System.Text.Json.Serialization;

namespace AmKart.Common.Models
{
    public class CreateOrder : BaseOrder
    {
        public Guid CustomerId { get; set; }

        [JsonConstructor]
        public CreateOrder(OrderItems[] orderItems, Guid customerId) : base(orderItems)
        {
            CustomerId = customerId;
        }
    }
}
