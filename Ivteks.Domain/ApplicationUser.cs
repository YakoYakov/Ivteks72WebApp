namespace Ivteks72.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;
   
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Orders = new HashSet<Order>();
            this.Invoices = new HashSet<Invoice>();
        }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        public string CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}
