using Ivteks72.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ivteks72.App.Models.Item
{
    public class AddItemViewModel
    {
        [Required]
        public ItemType Type { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
