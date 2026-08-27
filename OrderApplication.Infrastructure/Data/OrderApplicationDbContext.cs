using Microsoft.EntityFrameworkCore;
using OrderApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApplication.Infrastructure.Data
{
    public class OrderApplicationDbContext : DbContext
    {
        public OrderApplicationDbContext(
            DbContextOptions<OrderApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof (OrderApplicationDbContext).Assembly);
        }
    }
}
