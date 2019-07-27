namespace Ivteks72.Service
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.EntityFrameworkCore;

    using Ivteks72.Data;
    using Ivteks72.AutoMapping;
    using System.Threading.Tasks;
    using Ivteks72.Domain;
    using System;

    public class InvoiceService : IInvoiceService
    {
        private readonly Ivteks72DbContext context;

        public InvoiceService(Ivteks72DbContext context)
        {
            this.context = context;
        }

        public async Task CreateInvoice(string userId, string clothingId, string orderId)
        {
            var invoice = new Invoice
            {
                BIlledToId = userId,
                ClothingId = clothingId,
                DateOfIssue = DateTime.UtcNow,
                InvoiceSubTotal = 0,
                InvoiceTotalPrice = 0,
                OrderId = orderId
            };

            await this.context.Invoices.AddAsync(invoice);
            await this.context.SaveChangesAsync();
        }

        public IEnumerable<TViewModel> GetAllInovoices<TViewModel>()
        {
            var allInvoices = this.context.Invoices
                .Include(user => user.BilledTo)
                .Include(clothing => clothing.Clothing)
                .To<TViewModel>()
                .ToList();

            return allInvoices;
        }

        public IEnumerable<TViewModel> GetAllInovoicesByUserId<TViewModel>(string id)
        {
            var userInvoices = this.context.Invoices
                .Include(user => user.BilledTo)
                .Include(clothing => clothing.Clothing)
                .Where(user => user.BilledTo.Id == id)
                .To<TViewModel>()
                .ToList();

            return userInvoices;
        }

        public TViewModel GetInvoiceById<TViewModel>(string id)
        {
            var invoice = this.context.Invoices
                .Where(x => x.Id == id)
                .To<TViewModel>()
                .FirstOrDefault();

            return invoice;
        }
    }
}
