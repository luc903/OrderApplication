using OrderApplication.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApplication.Domain.Entities
{
    public class Order
    {
        private readonly List<OrderItem> _items = new();

        public int Id { get; private set; }
        public decimal Total { get; private set; }
        public OrderStatus Status { get; private set; }

        public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

        private Order()
        {

        }

        public static Order Create()
        {
            return new Order {
                Status = OrderStatus.Pending
            };
        }

        public void AddItem(int productId, string productName, decimal unitPrice, int quantity)
        {
            if (Status != OrderStatus.Pending)
            {
                throw new InvalidOperationException("Items can only be added to pending orders.");
            }

            if (quantity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(quantity));
            }

            if (unitPrice < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(unitPrice));
            }

            var item = new OrderItem(productId, productName, unitPrice, quantity);

            _items.Add(item);

            Total += unitPrice * quantity;
        }

        public void Cancel() 
        {
            if (Status == OrderStatus.Shipped)
            {
                throw new InvalidOperationException("A shipped order cannot be cancelled");
            }

            Status = OrderStatus.Cancelled;
        }
    }
}
