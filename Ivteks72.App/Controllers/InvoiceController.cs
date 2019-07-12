namespace Ivteks72.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Ivteks72.Service;
    using Ivteks72.App.Models.Invoice;

    [Authorize]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        public IActionResult InvoiceIndex()
        {
            var username = this.User.Identity.Name;

            var invoiceViewModels = this.invoiceService.GetAllInovoicesByUserName<InvoiceViewModel>(username);

            return this.View(invoiceViewModels);
        }
    }
}
