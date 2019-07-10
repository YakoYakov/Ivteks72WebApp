namespace Ivteks72.App.Models.Invoice
{
    using System;

    public class InvoiceViewModel
    {
        public string BIlledToUser { get; set; }

        public string CompanyName { get; set; }

        public string CompanyAddress { get; set; }

        public DateTime DateOfIssue { get; set; }

        public string ClothingName { get; set; }

        public int Quantity { get; set; }

        public decimal InvoiceSubTotal { get; set; }

        public decimal VAT { get; set; }

        public decimal InvoiceTotalPrice { get; set; }        
    }
}
