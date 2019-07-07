﻿namespace Ivteks72.Service
{
    using Ivteks72.Data;
    using Ivteks72.Domain;
    using Ivteks72.Domain.Enums;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class OrderService : IOrderService
    {
        private readonly Ivteks72DbContext context;

        public OrderService(Ivteks72DbContext context)
        {
            this.context = context;
        }

        public void CreateOrder(Clothing clothing, string issuerId)
        {
            var order = new Order
            {
                ClothingId = clothing.Id,
                IssuerId = issuerId,
                Quantity = clothing.Quantity,
                IssuedOn = DateTime.UtcNow,
                Status = Domain.Enums.OrderStatus.Pending
            };

            this.context.Orders.Add(order);
            this.context.SaveChanges();
        }

        public List<Order> GetOrdersByStatus(OrderStatus status)
        {
            var orders = this.context.Orders
                .Where(order => order.Status == status)
                .Include(clothing => clothing.Clothing)
                .Include(user => user.Issuer)
                .ThenInclude(company => company.Company)
                .ToList();

            return orders;
        }
    }
}