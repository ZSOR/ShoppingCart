using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using shoppingCart.Models;

namespace shoppingCart.Controllers
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        //Since I'm not using a db, I will just store the custoemrs in a list
        private List<Customer> customers = new List<Customer>{
            new Customer("Ross", "Test", "Test", CustomerType.Gold)
        };

        [HttpGet]
        [Route("")]
        public IEnumerable<Customer> Index() 
        {
            return customers;
        }
    }
}