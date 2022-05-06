using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.DataAccessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccessor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        
            builder.Entity<Entities.Type>()
            .HasData(
                new Entities.Type
                {
                    Id = Guid.NewGuid(),
                    Name = "test",
                    Desc="day la test, can thi bo sung trong code"
                }
                
            );
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Product> News { get; set; }
        public DbSet<Pictures> Pictures { get; set; }
        public DbSet<Entities.Type> Types { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItems> InvoiceItems { get; set; }


    }
}
