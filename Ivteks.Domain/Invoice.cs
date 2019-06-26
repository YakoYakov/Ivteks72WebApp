namespace Ivteks72.Domain
{
    using System;

    public class Invoice
    {
        public Invoice()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public decimal InvoiceSubTotal { get; set; }

        public decimal InvoiceTotalPrice { get; set; }

        public ApplicationUser BilledTo { get; set; }

        public DateTime DateOfIssue { get; set; }

        public Clothing Clothing { get; set; }

        public Order Order { get; set; }
    }
}
