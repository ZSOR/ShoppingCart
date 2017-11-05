using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace shoppingCart.Models
{
    public class Order
    {
        static int previousId = 0;

        private bool _orderConfirmed;

        public Order(Customer customer,
                     IList<OrderLine> orderLines)
        {
            Id = previousId += 1;
            CustomerName = customer.Name;
            Date = DateTime.Now;
            Address = customer.Address;
            OrderLines = orderLines;
            _orderConfirmed = false;
        }

        #region Public Attriubtes

        public int Id { get; }

        public string CustomerName
        {
            get { return CustomerName; }
            set
            {
                if (!OrderConfirmed)
                {
                    CustomerName = value;
                }
            }
        }

        public DateTime Date
        {
            get { return Date; }
            set
            {
                if (!OrderConfirmed)
                {
                    Date = value;
                }
            }
        }

        public string Address
        {
            get { return Address; }
            set
            {
                if (!OrderConfirmed)
                {
                    Address = value;
                }
            }
        }

        public decimal Amount { get { return CalculateTotal(); } }

        public IList<OrderLine> OrderLines { get; }

        public bool OrderConfirmed { get => _orderConfirmed; }

        #endregion

        #region Public Functions

        //Effectively makes the class immutable
        public void ConfirmOrder()
        {
            _orderConfirmed = true;
        }

        #endregion

        #region Private Functions

        private decimal CalculateTotal()
        {
            decimal total = 0;

            OrderLines.Select(x => total += x.Cost);

            return total;
        }

        #endregion
    }
}