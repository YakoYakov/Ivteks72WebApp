namespace Ivteks72.Domain
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Invoice
    {
        public Invoice()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public int Number { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal InvoiceSubTotal { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal InvoiceTotalPrice { get; set; }

        [Required]
        public string BIlledToId { get; set; }
        public ApplicationUser BilledTo { get; set; }

        [Required]
        public DateTime DateOfIssue { get; set; }

        [Required]
        public string ClothingId { get; set; }
        public Clothing Clothing { get; set; }

        [Required]
        public string OrderId { get; set; }
        public Order Order { get; set; }
    }
}
