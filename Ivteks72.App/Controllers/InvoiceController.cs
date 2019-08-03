namespace Ivteks72.App.Controllers
{
    using System.Linq;
    using System.Security.Claims;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Ivteks72.Service;
    using Ivteks72.App.Models.Invoice;
    using Ivteks72.Common;
    using Ivteks72.App.Pagination;

    [Authorize]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        public IActionResult InvoiceIndex(int? pageNumber)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var invoiceViewModels = this.invoiceService.GetAllInovoicesByUserId<InvoiceViewModel>(userId).ToList();

            int pageSize = GlobalConstants.DefaultPageSize;

            return this.View(PaginatedList<InvoiceViewModel>.Create(invoiceViewModels, pageNumber ?? 1, pageSize));
        }

        public IActionResult InvoiceDetails(string id)
        {
            var invoiceById = this.invoiceService.GetInvoiceById<InvoiceDetailsViewModel>(id);

            return this.View(invoiceById);
        }
    }
}
