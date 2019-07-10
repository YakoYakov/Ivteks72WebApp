namespace Ivteks72.App.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Ivteks72.Service;
    using Ivteks72.App.Models.Invoice;
    using System.Collections.Generic;
    using Ivteks72.Common;

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
            var invoicesFromDb = this.invoiceService.GetAllInovoicesByUserName(username);

            var invoicesViewModels = new List<InvoiceViewModel>();

            foreach (var invoice in invoicesFromDb)
            {
                var invoiceView = new InvoiceViewModel
                {
                    BIlledToUser = invoice.BilledTo.FullName,
                    CompanyName = invoice.BilledTo.Company.Name,
                    CompanyAddress = invoice.BilledTo.Company.Address,
                    DateOfIssue = invoice.DateOfIssue,
                    ClothingName = invoice.Clothing.Name,
                    Quantity = invoice.Clothing.Quantity,
                    InvoiceSubTotal = invoice.Clothing.PricePerUnit * invoice.Clothing.Quantity,
                    VAT = (invoice.Clothing.PricePerUnit * invoice.Clothing.Quantity) * GlobalConstants.VAT,
                    InvoiceTotalPrice = (invoice.Clothing.PricePerUnit * invoice.Clothing.Quantity) +
                                        ((invoice.Clothing.PricePerUnit * invoice.Clothing.Quantity) * GlobalConstants.VAT)
                };

                invoicesViewModels.Add(invoiceView);
            }

            return this.View(invoicesViewModels);
        }
    }
}
