namespace Ivteks72.App.Models.Clothing
{
    using System.ComponentModel.DataAnnotations;

    public class ClothingCreateViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        public string Fabric { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal PricePerUnit { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
