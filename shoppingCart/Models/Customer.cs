using System;
namespace shoppingCart.Models
{
    public enum CustomerType{
        Standard,
        Silver,
        Gold
    }

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

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public CustomerType Type { get; set; }

        public ShoppingCart Cart { get; set; }

        #endregion

        #region Public Functions

        public Order PlaceOrder()
        {
            return new Order(this, Cart.Items);   
        }

        #endregion

    }
}
