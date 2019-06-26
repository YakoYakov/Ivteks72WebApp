namespace Ivteks72.Domain
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Orders = new HashSet<Order>();
            this.Invoices = new HashSet<Invoice>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyId { get; set; }
        public Company Company { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}
