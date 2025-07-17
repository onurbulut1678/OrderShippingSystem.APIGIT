using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderShippingSystem.Domain.Entities;

namespace OrderShippingSystem.Infrastructure.Persistence
{
    public class OrderShippingDbContext :DbContext //kalıtım 
        // veritabanı işlemlerini burda yapacağız 
    {
        public OrderShippingDbContext(DbContextOptions<OrderShippingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<CargoCompany> CargoCompanies => Set<CargoCompany>();

        //entitieleri tabloya döktük
       // protected override void OnModelCreating(ModelBuilder modelBuilder)
     //   {
           // base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<OrderItem>()
              //  .HasOne(oi => oi.Order)
                //.WithMany(o => o.Items)
                //.HasForeignKey(oi => oi.OrderId);

          //  modelBuilder.Entity<Order>()
            //    .Property(o => o.TotalPrice)
              //  .HasColumnType("decimal(18,2)");

       //     modelBuilder.Entity<OrderItem>()
         //       .Property(oi => oi.UnitPrice)
           //     .HasColumnType("decimal(18,2)");
        //}
    }
}
