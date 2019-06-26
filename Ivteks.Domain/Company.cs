namespace Ivteks72.Domain
{
    using System;
    using System.Collections.Generic;

    public class Company
    {
        public Company()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Employees = new HashSet<ApplicationUser>();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public ICollection<ApplicationUser> Employees { get; set; }
    }
}
