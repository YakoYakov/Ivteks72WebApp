namespace Ivteks72.Data
{
    using Ivteks72.Domain;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class Ivteks72DbContext : IdentityDbContext
    {
        public Ivteks72DbContext(DbContextOptions<Ivteks72DbContext> options) : base(options)
        {}
    }
}
