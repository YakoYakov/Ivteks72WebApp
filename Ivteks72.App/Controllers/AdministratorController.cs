namespace Ivteks72.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Ivteks72.Common;
    using Ivteks72.Service;
    using Ivteks72.App.Models.Order;

    using System.Threading.Tasks;
    using Ivteks72.App.Models.Invoice;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministratorController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IInvoiceService invoiceService;

        public AdministratorController(IOrderService orderService, IInvoiceService invoiceService)
        {
            this.orderService = orderService;
            this.invoiceService = invoiceService;
        }

        public IActionResult ViewAllOrders()
        {
            var adminOrderAllViewModels = this.orderService
                .GetAllOrdersSortedByUserThenByCompany<AdminOrderViewModel>();

            return this.View(adminOrderAllViewModels);
        }

        public IActionResult ViewAllInvoices()
        {
            var adminInvoiceAllViewModel = this.invoiceService
                .GetAllInovoices<AdminAllInvoicesViewModel>();

            return this.View(adminInvoiceAllViewModel);
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
            if (model.OrderStatus == GlobalConstants.MakeInvoiceValue)
            {
                var orderFromDb = this.orderService.GetOrderFromDbById(model.Id);

                await this.invoiceService.CreateInvoice(orderFromDb.IssuerId, orderFromDb.ClothingId, orderFromDb.Id);
            }

            await this.orderService.EditOrderStatus(model.Id, model.OrderStatus);

            return this.Redirect("/Administrator/ViewAllOrders");
        }
    }
}
