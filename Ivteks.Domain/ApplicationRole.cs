namespace Ivteks72.Domain
{
    using Microsoft.AspNetCore.Identity;
    using System;

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
