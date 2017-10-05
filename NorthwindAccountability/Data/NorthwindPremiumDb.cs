using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthwindAccountability.Data.Models;

namespace NorthwindAccountability.Data
{
    public class NorthwindPremiumDb : DbContext
    {
        public DbSet<Party> Parties { get; set; }
        public DbSet<PartyInformation> PartyInformations { get; set; }
        public DbSet<Accountability> Accountabilities { get; set; }
        public DbSet<AccountabilityType> AccountabilityTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("hej");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Party>().HasOne(x => x.PartyInformation);


            modelBuilder.Entity<Accountability>().HasOne(x => x.Responsible)
                .WithMany(x => x.ResponsibleAccountabilities).HasForeignKey(x => x.ResponsibleId);
            modelBuilder.Entity<Accountability>().HasOne(x => x.Commissioner)
                .WithMany(x => x.CommisionerAccountabilities).HasForeignKey(x => x.CommissionerId);

            modelBuilder.Entity<Product>().HasOne(x => x.Category).WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<Product>().HasOne(x => x.Party).WithMany(x=> x.Products).HasForeignKey(x=> x.PartyId);

            modelBuilder.Entity<OrderDetail>().HasOne(x => x.Product);
            modelBuilder.Entity<OrderDetail>().HasOne(x => x.Order).WithMany(x => x.OrderDetails);
            modelBuilder.Entity<OrderDetail>().HasKey(x => new {x.OrderId, x.ProductId});


        base.OnModelCreating(modelBuilder);

        }
    }
}
