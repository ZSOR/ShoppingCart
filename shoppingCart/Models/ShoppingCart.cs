using System.Collections.Generic;
using System.Linq;

namespace shoppingCart.Models
{
    public class ShoppingCart
    {

        private IList<OrderLine> _items;

        public ShoppingCart(string customerName)
        {
            CustomerName = customerName;
            _items = new List<OrderLine>();
        }

        #region Attributes

        public string CustomerName { get; set; }

        public string ProductCode { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public IList<OrderLine> Items 
        { 
            get { return _items; }
        }
        #endregion

        #region public functions

        public void AddItem(Product product, int quantity)
        {
            _items.Add(new OrderLine(product, quantity));
        }

        public void RemoveItem(int itemId)
        {
            _items = _items.Where(x => x.OrderId != itemId).ToList();
        }

        public void ClearCart()
        {
            _items = new List<OrderLine>();
        }

        #endregion
    }
}
