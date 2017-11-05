using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using shoppingCart.Models;

namespace shoppingCart.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrderController : ApiController
    {
        public static List<Order> orders = new List<Order>();

        [HttpGet]
        [Route("")]
        public IList<Order> Index()
        {
            return orders;
        }

        [HttpGet]
        [Route("{id}")]
        public Order Get([FromUri] int id)
        {
            return orders.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        [Route("{id}/confirm")]
        public void Confirm([FromUri] int id)
        {
            orders.FirstOrDefault(x => x.Id == id).ConfirmOrder();
        }

    }
}
