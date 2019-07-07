namespace Ivteks72.App.Models.Order
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Ivteks72.Domain;
    using Ivteks72.Domain.Enums;
  
    public class OrderByStatusViewModel
    {
        [Required]
        public DateTime IssuedOn { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public string ClothingId { get; set; }
        public Clothing Clothing { get; set; }

        [Required]
        public string IssuerId { get; set; }
        public ApplicationUser Issuer { get; set; }
    }
}
