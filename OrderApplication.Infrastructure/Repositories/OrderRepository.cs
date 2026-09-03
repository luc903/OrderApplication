using Microsoft.EntityFrameworkCore;
using OrderApplication.Application.Orders;
using OrderApplication.Domain.Entities;
using OrderApplication.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApplication.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderApplicationDbContext _db;

        public OrderRepository(OrderApplicationDbContext db) { 
            _db  = db;
        }

        public async Task AddAsync(Order order, CancellationToken ct)
        {
            await _db.AddAsync(order, ct);
        }

        public async Task<Order?> GetByIdAsync(int id, CancellationToken ct)
        {
            return await _db.Orders
                .FirstOrDefaultAsync(o => o.Id == id, ct);
        }
    }
}
