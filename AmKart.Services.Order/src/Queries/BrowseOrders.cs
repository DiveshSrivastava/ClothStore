using AmKart.Common.Types;
using AmKart.Services.Order.Dto;

namespace AmKart.Services.Orders.Queries
{
    public class BrowseOrders : PagedQueryBase, IQuery<PagedResult<OrderDto>> { }
}