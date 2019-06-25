namespace Ivteks72.Data
{
    using Ivteks72.Domain;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class Ivteks72DbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public Ivteks72DbContext(DbContextOptions<Ivteks72DbContext> options) : base(options)
        {}
    }
}
