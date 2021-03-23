using System.ComponentModel.DataAnnotations;

namespace Ivteks72.Domain
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public int Quantity { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
