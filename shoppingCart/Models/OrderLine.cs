using System;
namespace shoppingCart.Models
{
    public class OrderLine
    {
        private static int previousId = 0;

        public OrderLine(string productCode, 
                        int quantity,
                        decimal unitPrice)
        {
            OrderId = previousId += 1;
            ProductCode = productCode;
            Quantity = quantity < 0 ? 0 : quantity;
            UnitPrice = unitPrice;
        }

        public int OrderId { get; set; }

        public string ProductCode { get; set; }

        public int Quantity { get; set; }
    
        public decimal UnitPrice { get; set; }
    
    }
}
