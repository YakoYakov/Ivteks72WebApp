namespace Ivteks72.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Ivteks72.Common;
    using Ivteks72.Service;
    using Ivteks72.App.Models.Order;
    using System.Threading.Tasks;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministratorController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IInvoiceService invoiceService;
        private readonly IClothingService clothingService;

        public AdministratorController(IOrderService orderService, IInvoiceService invoiceService, IClothingService clothingService)
        {
            this.orderService = orderService;
            this.invoiceService = invoiceService;
            this.clothingService = clothingService;
        }

        public IActionResult ViewAllOrders()
        {
            var adminOrderAllViewModels = this.orderService
                .GetAllOrdersSortedByUserThenByCompany<AdminOrderViewModel>();

            //foreach (var order in adminOrderAllViewModels)
            //{
            //    var image = this.clothingService.GetOrderImage(order.Id);

            //    order.Image = image;
            //}

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
