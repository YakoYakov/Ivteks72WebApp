namespace Ivteks72.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using Ivteks72.Data;
    using Ivteks72.Domain;
    using Microsoft.EntityFrameworkCore;

    public class InvoiceService : IInvoiceService
    {
        private readonly Ivteks72DbContext context;

        public InvoiceService(Ivteks72DbContext context)
        {
            this.context = context;
        }

        public List<Invoice> GetAllInovoicesByUserName(string username)
        {
            var userInvoices = this.context.Invoices
                .Include(user => user.BilledTo)
                .Include(clothing => clothing.Clothing)
                .Where(user => user.BilledTo.UserName == username)
                .ToList();

            return userInvoices;
        }
    }
}
