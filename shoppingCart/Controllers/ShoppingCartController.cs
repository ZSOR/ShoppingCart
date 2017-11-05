using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace shoppingCart.Controllers
{
    [RoutePrefix("api/shoppingCarts")]
    public class ShoppingCartController : Controller
    {


        public ActionResult Index()
        {
            return View ();
        }
    }
}
