using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace shoppingCart.Models
{
    [DataContract]
    public class Order
    {
        static int previousId = 0;

        private bool _orderConfirmed;
        private Customer _customer;

        public Order(Customer customer,
                     IList<OrderLine> orderLines)
        {
            Id = previousId += 1;
            CustomerName = customer.Name;
            Date = DateTime.Now;
            Address = customer.Address;
            OrderLines = orderLines;
            _orderConfirmed = false;
            _customer = customer;
        }

        #region Public Attriubtes

        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string CustomerName
        {
            get => CustomerName;
            set
            {
                if (!OrderConfirmed)
                {
                    CustomerName = value;
                }
            }
        }

        [DataMember]
        public DateTime Date
        {
            get => Date;
            set
            {
                if (!OrderConfirmed)
                {
                    Date = value;
                }
            }
        }

        [DataMember]
        public string Address
        {
            get => Address;
            set
            {
                if (!OrderConfirmed)
                {
                    Address = value;
                }
            }
        }

        [DataMember]
        public decimal Amount { get { return CalculateTotal(); } private set => Amount = value; }

        [DataMember]
        public IList<OrderLine> OrderLines { get; private set; }

        [DataMember]
        public bool OrderConfirmed
        {
            get => _orderConfirmed;
            private set { _orderConfirmed = value; }
        }

        #endregion

        #region Public Functions

        //Effectively makes the class immutable
        public void ConfirmOrder()
        {
            _orderConfirmed = true;
            //send email
            //get pay autherisation
        }

        #endregion

        #region Private Functions

        private decimal CalculateTotal()
        {
            decimal total = 0;

            OrderLines.Select(x => total += x.Cost);

            switch (_customer.Type)
            {
                case CustomerType.Gold:
                    return (decimal)0.97 * total;
                case CustomerType.Silver:
                    return (decimal)0.98 * total;
                default:
                    return total;
            }
        }

        #endregion
    }
}