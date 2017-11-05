using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using shoppingCart.Models;

namespace shoppingCart.Controllers
{
    [RoutePrefix("api/Customers")]
    public class CustomerController : ApiController
    {
        //Since I'm not using a db, I will just store the custoemrs in a list
        public static List<Customer> customers = new List<Customer>();

        [HttpGet]
        [Route("")]
        public IEnumerable<Customer> Index()
        {
            return customers;
        }

        [HttpGet]
        [Route("{name}")]
        public Customer Get([FromUri] string name)
        {
            return customers
                .FirstOrDefault(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant());
        }
        //Going to take the info from the URI to keep things simple
        [HttpPost]
        [Route("Create")]
        public void Create([FromBody] Customer customer)
        {
            customers.Add(customer);
        }

        [HttpPost]
        [Route("{name}/addToCart")]
        public void AddToCart([FromUri] string name, [FromBody] Product product, int quantity)
        {
            customers
                .FirstOrDefault(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant())
                    .Cart.AddItem(product, quantity);
        }

        [HttpDelete]
        [Route("{name}/removeFromCart/{itemId}")]
        public void RemoveFromCart([FromUri] string name, int itemId)
        {
            customers
                .FirstOrDefault(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant())
                     .Cart.RemoveItem(itemId);
        }

        [HttpDelete]
        [Route("{name}/emptyCart")]
        public void EmptyCart([FromUri] string name)
        {
            customers
                .FirstOrDefault(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant())
                   .Cart.ClearCart();
        }

        [HttpPost]
        [Route("{name}/generateOrder")]
        public void GenerateOrder([FromUri] string name)
        {
            OrderController.orders.Add(
                customers.FirstOrDefault(x => x.Name.ToLowerInvariant() == name.ToLowerInvariant())
                    .PlaceOrder());
        }
    }
}