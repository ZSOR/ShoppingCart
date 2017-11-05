using System.Runtime.Serialization;

namespace shoppingCart.Models
{
    [DataContract]
    public class OrderLine
    {
        private static int previousId = 0;

        public OrderLine(Product product,
                        int quantity)
        {
            Id = previousId += 1;
            Quantity = quantity < 0 ? 0 : quantity;
            Product = product;
        }

        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public int Quantity { get; private set; }

        [DataMember]
        public Product Product { get; private set; }

        [DataMember]
        public decimal Cost
        {
            get => Quantity * Product.UnitPrice;
            private set => Cost = value;
        }
    }
}
