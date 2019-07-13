﻿namespace Ivteks72.App.Controllers
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
            var acceptedOrders = this.orderService
                .GetOrdersByStatus<OrderByStatusViewModel>(OrderStatus.Accepted, this.User.Identity.Name);

            if (acceptedOrders.Count == 0)
            {
                return Redirect("NoOrders");
            }

            //var ordersView = new List<OrderByStatusViewModel>();

            //foreach (var orderFromDb in acceptedOrders)
            //{
            //    var viewOrder = new OrderByStatusViewModel
            //    {
            //        TotalOrderPrice = orderFromDb.Quantity * orderFromDb.Clothing.PricePerUnit,
            //        Clothing = orderFromDb.Clothing.Name,
            //        Quantity = orderFromDb.Quantity,
            //        Company = orderFromDb.Issuer.Company.Name,
            //        IssuedOn = orderFromDb.IssuedOn,
            //        Status = OrderStatus.Accepted.ToString(),
            //        IssuerName = orderFromDb.Issuer.FullName
            //    };

            //    ordersView.Add(viewOrder);
            //}

            return this.View(acceptedOrders);
        }

        public IActionResult Rejected()
        {
            var rejectedOrders = this.orderService
                .GetOrdersByStatus<OrderByStatusViewModel>(OrderStatus.Rejected, this.User.Identity.Name);

            if (rejectedOrders.Count == 0)
            {
                return Redirect("NoOrders");
            }

            //var ordersView = new List<OrderByStatusViewModel>();

            //foreach (var orderFromDb in rejectedOrders)
            //{
            //    var viewOrder = new OrderByStatusViewModel
            //    {
            //        TotalOrderPrice = orderFromDb.Quantity * orderFromDb.Clothing.PricePerUnit,
            //        Clothing = orderFromDb.Clothing.Name,
            //        Quantity = orderFromDb.Quantity,
            //        Company = orderFromDb.Issuer.Company.Name,
            //        IssuedOn = orderFromDb.IssuedOn,
            //        Status = OrderStatus.Rejected.ToString(),
            //        IssuerName = orderFromDb.Issuer.FullName
            //    };

            //    ordersView.Add(viewOrder);
            //}

            return this.View(rejectedOrders);
        }

        public IActionResult Finished()
        {
            var finishedOrders = this.orderService
                .GetOrdersByStatus<OrderByStatusViewModel>(OrderStatus.Finished, this.User.Identity.Name);

            if (finishedOrders.Count == 0)
            {
                return Redirect("NoOrders");
            }

            //var ordersView = new List<OrderByStatusViewModel>();

            //foreach (var orderFromDb in finishedOrders)
            //{
            //    var viewOrder = new OrderByStatusViewModel
            //    {
            //        TotalOrderPrice = orderFromDb.Quantity * orderFromDb.Clothing.PricePerUnit,
            //        Clothing = orderFromDb.Clothing.Name,
            //        Quantity = orderFromDb.Quantity,
            //        Company = orderFromDb.Issuer.Company.Name,
            //        IssuedOn = orderFromDb.IssuedOn,
            //        Status = OrderStatus.Finished.ToString(),
            //        IssuerName = orderFromDb.Issuer.FullName
            //    };

            //    ordersView.Add(viewOrder);
            //}

            return this.View(finishedOrders);
        }

        public IActionResult Pending()
        {
            var pendingOrdersFromDb = this.orderService
                .GetOrdersByStatus<OrderByStatusViewModel>(OrderStatus.Pending, this.User.Identity.Name);

            if (pendingOrdersFromDb.Count == 0)
            {
                return Redirect("NoOrders");
            }

            //var ordersView = new List<OrderByStatusViewModel>();

            //foreach (var orderFromDb in pendingOrdersFromDb)
            //{
            //    var viewOrder = new OrderByStatusViewModel
            //    {
            //        TotalOrderPrice = orderFromDb.Quantity * orderFromDb.Clothing.PricePerUnit,
            //        Clothing = orderFromDb.Clothing.Name,
            //        Quantity = orderFromDb.Quantity,
            //        Company = orderFromDb.Issuer.Company.Name,
            //        IssuedOn = orderFromDb.IssuedOn,
            //        Status = OrderStatus.Pending.ToString(),
            //        IssuerName = orderFromDb.Issuer.FullName
            //    };

            //    ordersView.Add(viewOrder);
            //}

            return this.View(pendingOrdersFromDb);
        }

        public IActionResult ViewAll()
        {
            return this.View();
        }
    }
}
