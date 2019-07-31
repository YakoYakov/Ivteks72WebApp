namespace Ivteks72.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Ivteks72.Common;
    using Ivteks72.Service;
    using Ivteks72.App.Models.Order;

    using System.Threading.Tasks;
    using Ivteks72.App.Models.Invoice;
    using System.Linq;

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

        public IActionResult ViewAllOrders(string sortOrder)
        {
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "issuerName_desc" : "";
            ViewData["CompanyNameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "companyName_desc" : "";
            ViewData["ClothingNameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "clothingName_desc" : "";
            ViewData["QuantitySortParm"] = string.IsNullOrEmpty(sortOrder) ? "quantity_desc" : "";
            ViewData["PricePerUnitSortParm"] = string.IsNullOrEmpty(sortOrder) ? "pricePerUnit_desc" : "";
            ViewData["OrderStatusSortParm"] = string.IsNullOrEmpty(sortOrder) ? "orderStatus_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            var adminOrderAllViewModels = this.orderService
                .GetAllOrdersSortedByUserThenByCompany<AdminOrderViewModel>();

            switch (sortOrder)
            {
                case "issuerName_desc":
                    adminOrderAllViewModels = adminOrderAllViewModels.OrderByDescending(a => a.IssuerName).ToList();
                    break;
                case "companyName_desc":
                    adminOrderAllViewModels = adminOrderAllViewModels.OrderByDescending(a => a.CompanyName).ToList();
                    break;
                case "clothingName_desc":
                    adminOrderAllViewModels = adminOrderAllViewModels.OrderByDescending(a => a.ClothingName).ToList();
                    break;
                case "quantity_desc":
                    adminOrderAllViewModels = adminOrderAllViewModels.OrderByDescending(a => a.Quantity).ToList();
                    break;
                case "pricePerUnit_desc":
                    adminOrderAllViewModels = adminOrderAllViewModels.OrderByDescending(a => a.PricePerUnit).ToList();
                    break;
                case "orderStatus_desc":
                    adminOrderAllViewModels = adminOrderAllViewModels.OrderByDescending(a => a.OrderStatus).ToList();
                    break;
                case "Date":
                    adminOrderAllViewModels = adminOrderAllViewModels.OrderBy(a => a.IssuedOn).ToList();
                    break;
                case "date_desc":
                    adminOrderAllViewModels = adminOrderAllViewModels.OrderByDescending(a => a.IssuedOn).ToList();
                    break;
                default:
                    adminOrderAllViewModels = adminOrderAllViewModels.OrderBy(a => a.IssuerName).ToList();
                    break;
            }

            return this.View(adminOrderAllViewModels);
        }

        public IActionResult ViewAllInvoices(string sortOrder)
        {       
            var adminInvoiceAllViewModel = this.invoiceService
                .GetAllInovoices<InvoiceViewModel>();

            return this.View(adminInvoiceAllViewModel);
        }

        public IActionResult Edit(string id)
        {
            var order = this.orderService
                .GetOrderById<AdminChangeOrderViewModel>(id);

            return this.View(order);
        }

        public  IActionResult InvoiceDetails(string id)
        {
            var invoiceById = this.invoiceService.GetInvoiceById<InvoiceDetailsViewModel>(id);

            return this.View(invoiceById);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminChangeOrderViewModel model)
        {
            if (model.OrderStatus == GlobalConstants.MakeInvoiceValue)
            {
                var orderFromDb = this.orderService.GetOrderFromDbById(model.Id);

                await this.invoiceService.CreateInvoiceAsync(orderFromDb.IssuerId, orderFromDb.ClothingId, orderFromDb.Id);
            }

            await this.orderService.EditOrderStatusAsync(model.Id, model.OrderStatus);

            return this.Redirect("/Administrator/ViewAllOrders");
        }
    }
}
