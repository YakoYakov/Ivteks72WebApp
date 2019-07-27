namespace Ivteks72.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Ivteks72.Data;
    using Ivteks72.Domain;
    using Ivteks72.Domain.Enums;
    using Ivteks72.AutoMapping;
    

    public class OrderService : IOrderService
    {
        private readonly Ivteks72DbContext context;

        public OrderService(Ivteks72DbContext context)
        {
            this.context = context;
        }

        public async Task CreateOrderAsync(Clothing clothing, string issuerId)
        {
            var order = new Order
            {
                ClothingId = clothing.Id,
                IssuerId = issuerId,
                Quantity = clothing.Quantity,
                IssuedOn = DateTime.UtcNow,
                Status = Domain.Enums.OrderStatus.Pending
            };

            await this.context.Orders.AddAsync(order);
            await this.context.SaveChangesAsync();
        }

        public async Task EditOrderStatusAsync(string id, string status)
        {
            var orderToEdit = this.context.Orders.Find(id);

            OrderStatus newStatus;

            Enum.TryParse(status, out newStatus);

            orderToEdit.Status = newStatus;

            this.context.Orders.Update(orderToEdit);
            await this.context.SaveChangesAsync();
        }

        public List<TOrderViewModel> GetAllOrdersSortedByUserThenByCompany<TOrderViewModel>()
        {
            var adminOrderViewModels = this.context.Orders
                .OrderBy(user => user.Issuer.UserName)
                .ThenBy(company => company.Issuer.Company.Name)
                .To<TOrderViewModel>()
                .ToList();

            return adminOrderViewModels;
        }

        public TOrderViewModel GetOrderById<TOrderViewModel>(string id)
        {
            var orderEditViewModel = this.context.Orders
                .Where(order => order.Id == id)
                .To<TOrderViewModel>()
                .FirstOrDefault();

            return orderEditViewModel;
        }

        public Order GetOrderFromDbById(string id)
        {
            var order = this.context.Orders.Find(id);

            return order;
        }

        public List<TOrderViewModel> GetOrdersByStatus<TOrderViewModel>(OrderStatus status, string username)
        {
            var orderViewModels = this.context.Orders
                .Where(order => order.Status == status && order.Issuer.UserName == username)
                .To<TOrderViewModel>()
                .ToList();

            return orderViewModels;
        }
    }
}
