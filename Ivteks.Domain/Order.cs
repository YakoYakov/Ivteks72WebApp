namespace Ivteks72.Domain
{
    using Ivteks72.Domain.Enums;
    using System;

    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public int Quantity { get; set; }

        public OrderStatus Status { get; set; }

        public string ClothingId { get; set; }
        public Clothing Clothing { get; set; }

        public string IssuerId { get; set; }
        public ApplicationUser Issuer { get; set; }
    }
}
