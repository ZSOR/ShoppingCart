using System;
using System.Runtime.Serialization;

namespace shoppingCart.Models
{
    [DataContract]
    public class Product
    {
        public Product(
            string code,
            string description,
            decimal unitPrice)
        {
            Code = code;
            Description = description;
            UnitPrice = unitPrice;
        }

        [DataMember]
        public string Code { get; private set; }

        [DataMember]
        public string Description { get; private set; }

        [DataMember]
        public decimal UnitPrice { get; private set; }
    }
}
