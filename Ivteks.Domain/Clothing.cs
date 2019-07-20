namespace Ivteks72.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Clothing
    {
        public Clothing()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Orders = new HashSet<Order>();
        }

        public string Id { get; set; }

        [Required]
        [StringLength (50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Fabric { get; set; }
        
        public string ClothingDiagramId { get; set; }
        public ClothingDiagram ClothingPatternsAndCuttingDiagram { get; set; }

        [Required]
        [Range(typeof(decimal),"0.01", "79228162514264337593543950335")]
        public decimal PricePerUnit { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
