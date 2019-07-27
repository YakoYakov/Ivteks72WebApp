namespace Ivteks72.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Ivteks72.Service;
    using Ivteks72.App.Models.Invoice;
    using System.Security.Claims;

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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var invoiceViewModels = this.invoiceService.GetAllInovoicesByUserId<InvoiceViewModel>(userId);

            return this.View(invoiceViewModels);
        }

        public IActionResult InvoiceDetails(string id)
        {
            var invoiceById = this.invoiceService.GetInvoiceById<InvoiceDetailsViewModel>(id);

            return this.View(invoiceById);
        }
    }
}
