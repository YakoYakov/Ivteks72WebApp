﻿namespace Ivteks72.Data
{
    using Ivteks72.Domain;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class Ivteks72DbContext : IdentityDbContext<ApplicationUser>
    {
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

            base.OnModelCreating(builder);
        }
    }
}
