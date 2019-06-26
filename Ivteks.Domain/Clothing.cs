namespace Ivteks72.Domain
{
    using System;
    using System.Collections.Generic;

    public class Clothing
    {
        public Clothing()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Orders = new HashSet<Order>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Fabric { get; set; }

        public byte[] ClothingPatternsAndCuttingDiagram { get; set; }

        public decimal PricePerUnit { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
