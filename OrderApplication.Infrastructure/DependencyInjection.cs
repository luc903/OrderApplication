using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderApplication.Application.Common;
using OrderApplication.Application.Orders;
using OrderApplication.Infrastructure.Data;
using OrderApplication.Infrastructure.Persistence;
using OrderApplication.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApplication.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            var connectionString = 
                configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<OrderApplicationDbContext>(options => 
                options.UseSqlServer(connectionString));

            //Add services
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
