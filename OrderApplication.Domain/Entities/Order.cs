using OrderApplication.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApplication.Domain.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public decimal Total { get; private set; }
        public OrderStatus Status { get; private set; }

        private Order()
        {

        }

        public Order(decimal total)
        {
            Total = total;
            Status = OrderStatus.Pending;
        }

        public void Cancel() 
        {
            if (Status == OrderStatus.Shipped)
            {
                throw new InvalidOperationException("A shipped order cannot be cancelled");
            }
        }
    }
}
