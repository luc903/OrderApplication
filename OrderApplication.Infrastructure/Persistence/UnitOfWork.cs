using OrderApplication.Application.Common;
using OrderApplication.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApplication.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrderApplicationDbContext _db;

        public UnitOfWork(OrderApplicationDbContext db)
        {
            _db = db;
        }

        public async Task SaveChangesAsync(CancellationToken ct)
        {
            await _db.SaveChangesAsync(ct);
        }
    }
}
