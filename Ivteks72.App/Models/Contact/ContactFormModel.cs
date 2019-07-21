using System.ComponentModel.DataAnnotations;

namespace Ivteks72.App.Models.Contact
{
    public class ContactFormModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Massage { get; set; }
    }
}
