using System;
namespace shoppingCart.Models
{
    public class Order
    {
        public Order(
            string code,
            string description,
            decimal unitPrice)
        {
            Code = code;
            Description = description;
            UnitPrice = unitPrice;
        }


        public string Code {get; set;}

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
