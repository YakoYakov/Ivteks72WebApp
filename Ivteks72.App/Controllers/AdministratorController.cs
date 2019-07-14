namespace Ivteks72.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Ivteks72.Common;
    using Ivteks72.Service;
    using Ivteks72.App.Models.Order;
    using System.Threading.Tasks;
    using Ivteks72.Domain.Enums;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministratorController : Controller
    {
        private readonly IOrderService orderService;

        public AdministratorController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public IActionResult ViewAllOrders()
        {
            var adminOrderAllViewModels = this.orderService
                .GetAllOrdersSortedByUserThenByCompany<AdminOrderViewModel>();

            return this.View(adminOrderAllViewModels);
        }

        public IActionResult Edit(string id)
        {
            var order = this.orderService
                .GetOrderById<AdminChangeOrderViewModel>(id);            

            return this.View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminChangeOrderViewModel model)
        {    

          await this.orderService.EditOrderStatus(model.Id, model.OrderStatus);

            return this.Redirect("/Administrator/ViewAllOrders");
        }
    }
}
