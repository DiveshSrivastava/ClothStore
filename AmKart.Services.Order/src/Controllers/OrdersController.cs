using AmKart.Common.Dispatchers;
using AmKart.Common.Mvc;

namespace AmKart.Services.Product.Controllers
{
    public class OrdersController : BaseController
    {
        public OrdersController(IDispatcher dispatcher) : base(dispatcher) { }
    }
}