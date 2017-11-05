using System.Runtime.Serialization;

namespace shoppingCart.Models
{
    public enum CustomerType{
        Standard,
        Silver,
        Gold
    }
    [DataContract]
    public class Customer
    {
        public Customer(string name,
                       string email,
                       string address,
                        CustomerType type)
        {
            Name = name;
            Email = email;
            Address = address;
            Type = type;
            Cart = new ShoppingCart(name);
        }

        #region Public Attributes
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public CustomerType Type { get; set; }

        [DataMember]
        public ShoppingCart Cart { get; private set; }

        #endregion

        #region Public Functions

        public Order PlaceOrder()
        {
            return new Order(this, Cart.Items);   
        }

        #endregion

    }
}
