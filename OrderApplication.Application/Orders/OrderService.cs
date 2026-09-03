using OrderApplication.Application.Common;
using OrderApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApplication.Application.Orders
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork) { 
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateOrder(CreateOrderDto dto, CancellationToken ct)
        {
            var orderEntity = Order.Create();

            foreach (var item in dto.Items)
            {
                orderEntity.AddItem(item.ProductId, item.ProductName, item.UnitPrice, item.Quantity);
            }

            await _orderRepository.AddAsync(orderEntity, ct);
            await _unitOfWork.SaveChangesAsync(ct);
            
            return orderEntity.Id;
        }

        public async Task CancelOrder(int id, CancellationToken ct)
        {
            var order = await _orderRepository.GetByIdAsync(id, ct);

            order.Cancel();

            await _unitOfWork.SaveChangesAsync(ct);
        }

        public async Task<Order?> GetOrder(int id, CancellationToken ct)
        {
            return await _orderRepository.GetByIdAsync(id, ct);
        }
    }
}
