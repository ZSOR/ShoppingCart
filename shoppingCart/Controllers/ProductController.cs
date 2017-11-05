using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using shoppingCart.Models;

namespace shoppingCart.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        public static List<Product> products = new List<Product>();

        [HttpGet]
        [Route("")]
        public List<Product> Index()
        {
            return products;
        }

        [HttpGet]
        [Route("{code}")]
        public Product Get([FromUri] string code)
        {
            return products.FirstOrDefault(x => x.Code == code);
        }

        [HttpPost]
        [Route("Create")]
        public void Create([FromBody] Product product ){
            products.Add(product);
        }

 
    }
}
