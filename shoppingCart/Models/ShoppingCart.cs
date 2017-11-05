using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace shoppingCart.Models
{
    [DataContract]
    public class ShoppingCart
    {

        private IList<OrderLine> _items;

        public ShoppingCart(string customerName)
        {
            CustomerName = customerName;
            _items = new List<OrderLine>();
        }

        #region Attributes
        [DataMember]
        public string CustomerName { get; private set; }

        [DataMember]
        public string ProductCode { get; private set; }

        [DataMember]
        public int Quantity { get; private set; }

        [DataMember]
        public decimal UnitPrice { get; private set; }

        [DataMember]
        public IList<OrderLine> Items
        {
            get { return _items; }
            private set { _items = value; }
        }
        #endregion

        #region public functions

        public void AddItem(Product product, int quantity)
        {
            _items.Add(new OrderLine(product, quantity));
        }

        public void RemoveItem(int itemId)
        {
            _items = _items.Where(x => x.Id != itemId).ToList();
        }

        public void ClearCart()
        {
            _items = new List<OrderLine>();
        }

        #endregion
    }
}
