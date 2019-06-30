namespace Ivteks72.Domain
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Company
    {
        public Company()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Employees = new HashSet<ApplicationUser>();
        }
        public string Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        public ICollection<ApplicationUser> Employees { get; set; }
    }
}
