namespace Ivteks72.App.Models.Invoice
{
    using System;

    public class InvoiceViewModel
    {
        public decimal InvoiceSubTotal { get; set; }

        public decimal InvoiceTotalPrice { get; set; }

        public string BIlledToUser { get; set; }

        public DateTime DateOfIssue { get; set; }

        public string ClothingName { get; set; }
    }
}
