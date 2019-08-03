namespace Ivteks72.App.Models.Contact
{
    using System.ComponentModel.DataAnnotations;

    public class ContactFormModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Massage { get; set; }
    }
}
