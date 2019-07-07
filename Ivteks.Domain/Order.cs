namespace Ivteks72.Domain
{
    using Ivteks72.Domain.Enums;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public DateTime IssuedOn { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Required]
        public string ClothingId { get; set; }
        public Clothing Clothing { get; set; }

        [Required]
        public string IssuerId { get; set; }
        public ApplicationUser Issuer { get; set; }
    }
}
