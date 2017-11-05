using System;
namespace shoppingCart.Models
{
    public class OrderLine
    {
        private static int previousId = 0;

        public OrderLine(Product product,
                        int quantity)
        {
            OrderId = previousId += 1;
            Quantity = quantity < 0 ? 0 : quantity;
            Product = product;
        }

        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public Product Product { get; set; }

    }
}
