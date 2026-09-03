using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApplication.Infrastructure.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItem");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.OrderId).IsRequired();

            builder.Property(x => x.ProductId).IsRequired();

            builder.Property(x => x.ProductName).IsRequired();

            builder.Property(x => x.Quantity).IsRequired();

            builder.Property(x => x.UnitPrice)
                .HasPrecision(18, 2)
                .IsRequired();
        }
    }
}
