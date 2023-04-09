using System.Text.Json.Serialization;

namespace AmKart.Common.Models
{
    public class BaseOrder
    {
		public OrderItems[] OrderItems { get; set; }

		[JsonConstructor]
		public BaseOrder(OrderItems[] orderItems)
		{
			OrderItems = orderItems;
		}
	}
}
