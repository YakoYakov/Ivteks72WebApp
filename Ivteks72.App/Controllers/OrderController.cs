namespace Ivteks72.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Ivteks72.App.Models.Order;
    using Ivteks72.App.Pagination;
    using Ivteks72.Common;
    using Ivteks72.Domain.Enums;
    using Ivteks72.Service;


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

        public IActionResult Accept(int? pageNumber)
        {
            var acceptedOrders = this.orderService
                .GetOrdersByStatus<OrderByStatusViewModel>(OrderStatus.Accepted, this.User.Identity.Name);

            if (acceptedOrders.Count == 0)
            {
                return Redirect("NoOrders");
            }

            int pageSize = GlobalConstants.DefaultPageSize;
            return this.View(PaginatedList<OrderByStatusViewModel>.Create(acceptedOrders, pageNumber ?? 1, pageSize));
        }

        public IActionResult Rejected(int? pageNumber)
        {
            var rejectedOrders = this.orderService
                .GetOrdersByStatus<OrderByStatusViewModel>(OrderStatus.Rejected, this.User.Identity.Name);

            if (rejectedOrders.Count == 0)
            {
                return Redirect("NoOrders");
            }

            int pageSize = GlobalConstants.DefaultPageSize;
            return this.View(PaginatedList<OrderByStatusViewModel>.Create(rejectedOrders, pageNumber ?? 1, pageSize));
        }

        public IActionResult Finished(int? pageNumber)
        {
            var finishedOrders = this.orderService
                .GetOrdersByStatus<OrderByStatusViewModel>(OrderStatus.Finished, this.User.Identity.Name);

            if (finishedOrders.Count == 0)
            {
                return Redirect("NoOrders");
            }

            int pageSize = GlobalConstants.DefaultPageSize;
            return this.View(PaginatedList<OrderByStatusViewModel>.Create(finishedOrders, pageNumber ?? 1, pageSize));
        }

        public IActionResult Pending(int? pageNumber)
        {
            var pendingOrders = this.orderService
                .GetOrdersByStatus<OrderByStatusViewModel>(OrderStatus.Pending, this.User.Identity.Name);

            if (pendingOrders.Count == 0)
            {
                return Redirect("NoOrders");
            }

            int pageSize = GlobalConstants.DefaultPageSize;
            return this.View(PaginatedList<OrderByStatusViewModel>.Create(pendingOrders, pageNumber ?? 1, pageSize));
        }
    }
}
