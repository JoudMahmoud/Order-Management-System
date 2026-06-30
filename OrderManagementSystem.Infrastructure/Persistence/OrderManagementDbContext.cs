using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Infrastructure.Persistence
{
    public class OrderManagementDbContext:IdentityDbContext<User>
    {
        public OrderManagementDbContext(DbContextOptions<OrderManagementDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrdersItems { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>()
               .Property(u => u.Email)
               .IsRequired();
            builder.Entity<User>()
             .HasIndex(u => u.NormalizedEmail)
             .IsUnique();

            builder.Entity<Order>(entity =>
            {
                entity.Property(p => p.PaymentMethod).HasConversion<string>();
                entity.Property(p => p.Status).HasConversion<string>();
            });
        }
    }
}
