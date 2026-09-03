using OrderApplication.Domain.Entities;
using OrderApplication.Domain.Enums;

namespace OrderApplication.Application.Orders
{
    public class CreateOrderDto
    {
        public List<OrderItem> Items { get; set; } = new();
    }
}
