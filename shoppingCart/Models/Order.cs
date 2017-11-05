using System;
using System.Collections;

namespace shoppingCart.Models
{
    public class Order
    {
        static int previousId = 0;

        public Order(Customer customer,
                     decimal amount,
                     IEnumerable orderLines)
        {
            Id = previousId += 1;
            CustomerName = customer.Name;
            Date = DateTime.Now;
            Address = customer.Address;
            Amount = amount;
            OrderLines = orderLines;
        }

        public int Id { get; set; }

        public string CustomerName { get; set; }

        public DateTime Date { get; set; }

        public string Address { get; set; }

        public decimal Amount { get; set; }
    
        public IEnumerable OrderLines { get; set; }
    }
}