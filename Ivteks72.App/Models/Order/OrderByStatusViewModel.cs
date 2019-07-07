namespace Ivteks72.App.Models.Order
{
    using System;
  
    public class OrderByStatusViewModel
    {
        public string Clothing { get; set; }

        public int Quantity { get; set; }

        public DateTime IssuedOn { get; set; }

        public string IssuerName { get; set; }

        public string Company { get; set; }

        public decimal TotalOrderPrice { get; set; }

        public string Status { get; set; }
    }
}
