namespace Ivteks72.App.Controllers
{
    using Ivteks72.App.Models.Order;
    using Ivteks72.Domain.Enums;
    using Ivteks72.Service;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult OrderIndex()
        {

            return this.View();
        }

        public IActionResult NoOrders()
        {
            return this.View();
        }

        public IActionResult Accept()
        {
            var acceptedOrders = this.orderService.GetOrdersByStatus(OrderStatus.Accepted);

            if (acceptedOrders.Count == 0)
            {
                return Redirect("NoOrders");
            }

            var ordersView = new List<OrderByStatusViewModel>();

            foreach (var orderFromDb in acceptedOrders)
            {
                var viewOrder = new OrderByStatusViewModel
                {
                    TotalOrderPrice = orderFromDb.Quantity * orderFromDb.Clothing.PricePerUnit,
                    Clothing = orderFromDb.Clothing.Name,
                    Quantity = orderFromDb.Quantity,
                    Company = orderFromDb.Issuer.Company.Name,
                    IssuedOn = orderFromDb.IssuedOn,
                    Status = OrderStatus.Pending.ToString(),
                    IssuerName = orderFromDb.Issuer.FullName
                };

                ordersView.Add(viewOrder);
            }

            return this.View(ordersView);
        }

        public IActionResult Rejected()
        {
            var rejectedOrders = this.orderService.GetOrdersByStatus(OrderStatus.Rejected);

            if (rejectedOrders.Count == 0)
            {
                return Redirect("NoOrders");
            }

            var ordersView = new List<OrderByStatusViewModel>();

            foreach (var orderFromDb in rejectedOrders)
            {
                var viewOrder = new OrderByStatusViewModel
                {
                    TotalOrderPrice = orderFromDb.Quantity * orderFromDb.Clothing.PricePerUnit,
                    Clothing = orderFromDb.Clothing.Name,
                    Quantity = orderFromDb.Quantity,
                    Company = orderFromDb.Issuer.Company.Name,
                    IssuedOn = orderFromDb.IssuedOn,
                    Status = OrderStatus.Pending.ToString(),
                    IssuerName = orderFromDb.Issuer.FullName
                };

                ordersView.Add(viewOrder);
            }

            return this.View(ordersView);
        }

        public IActionResult Finished()
        {
            var finishedOrders = this.orderService.GetOrdersByStatus(OrderStatus.Finished);

            if (finishedOrders.Count == 0)
            {
                return Redirect("NoOrders");
            }

            var ordersView = new List<OrderByStatusViewModel>();

            foreach (var orderFromDb in finishedOrders)
            {
                var viewOrder = new OrderByStatusViewModel
                {
                    TotalOrderPrice = orderFromDb.Quantity * orderFromDb.Clothing.PricePerUnit,
                    Clothing = orderFromDb.Clothing.Name,
                    Quantity = orderFromDb.Quantity,
                    Company = orderFromDb.Issuer.Company.Name,
                    IssuedOn = orderFromDb.IssuedOn,
                    Status = OrderStatus.Pending.ToString(),
                    IssuerName = orderFromDb.Issuer.FullName
                };

                ordersView.Add(viewOrder);
            }

            return this.View(ordersView);
        }

        public IActionResult Pending()
        {
            var pendingOrdersFromDb = this.orderService.GetOrdersByStatus(OrderStatus.Pending);

            if (pendingOrdersFromDb.Count == 0)
            {
                return Redirect("NoOrders");
            }

            var ordersView = new List<OrderByStatusViewModel>();

            foreach (var orderFromDb in pendingOrdersFromDb)
            {
                var viewOrder = new OrderByStatusViewModel
                {
                    TotalOrderPrice = orderFromDb.Quantity * orderFromDb.Clothing.PricePerUnit,
                    Clothing = orderFromDb.Clothing.Name,
                    Quantity = orderFromDb.Quantity,
                    Company = orderFromDb.Issuer.Company.Name,
                    IssuedOn = orderFromDb.IssuedOn,
                    Status = OrderStatus.Pending.ToString(),
                    IssuerName = orderFromDb.Issuer.FullName
                };

                ordersView.Add(viewOrder);
            }

            return this.View(ordersView);
        }

        public IActionResult ViewAll()
        {
            return this.View();
        }
    }
}
