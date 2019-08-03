namespace Ivteks72.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Ivteks72.Domain;

    public class Ivteks72DbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public DbSet<Clothing> Clothings { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ApplicationRole> ApplicationRoles { get; set; }

        public Ivteks72DbContext(DbContextOptions<Ivteks72DbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Clothing>()
                .Property(pricePerUnit => pricePerUnit.PricePerUnit)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Invoice>()
               .Property(invoiceTotal => invoiceTotal.InvoiceTotalPrice)
               .HasColumnType("decimal(18,2)");

            builder.Entity<Invoice>()
               .Property(invoiceSub => invoiceSub.InvoiceSubTotal)
               .HasColumnType("decimal(18,2)");

            builder.Entity<Order>()
                .HasOne(c => c.Clothing)
                .WithMany(o => o.Orders)
                .HasForeignKey(c => c.ClothingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasSequence<int>("Invoice_seq", schema: "dbo")
            .StartsAt(1)
            .IncrementsBy(1);

            builder.Entity<Invoice>()
                .Property(i => i.Number)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.Order_seq");

            base.OnModelCreating(builder);
        }
    }
}
