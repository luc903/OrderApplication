using OrderApplication.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApplication.Application.Orders
{
    public class OrderDto
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public OrderStatus Status { get; set; }
    }
}
