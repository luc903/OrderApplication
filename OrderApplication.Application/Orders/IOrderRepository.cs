using OrderApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApplication.Application.Orders
{
    public interface IOrderRepository
    {
        public Task<Order?> GetByIdAsync(int id, CancellationToken ct);
        public Task AddAsync(Order order, CancellationToken ct);
    }
}
