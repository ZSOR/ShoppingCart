using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using shoppingCart.Models;

namespace shoppingCart.Controllers
{
    [RoutePrefix("api/orderLines")]
    public class OrderLineController : ApiController
    {

        public static List<OrderLine> orderLines = new List<OrderLine>();

        [HttpGet]
        [Route("")]
        public IList<OrderLine> Index()
        {
            return orderLines;
        }

        [HttpGet]
        [Route("{id}")]
        public OrderLine Get([FromUri] int id)
        {
            return orderLines.FirstOrDefault(x => x.Id == id);
        }
    }
}
