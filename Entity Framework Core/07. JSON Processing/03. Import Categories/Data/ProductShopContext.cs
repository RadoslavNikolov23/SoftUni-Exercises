﻿using Microsoft.EntityFrameworkCore;
using ProductShop.Models;
namespace ProductShop.Data
{
    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
        {
        }

        public ProductShopContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<CategoryProduct> CategoriesProducts { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>(entity =>
            {
                entity.HasKey(x => new { x.CategoryId, x.ProductId });
            });

            //modelBuilder.Entity<User>(entity =>
            //{
            //    entity.HasMany(x => x.ProductsBought)
            //          .WithOne(x => x.Buyer)
            //          .HasForeignKey(x => x.BuyerId)
            //          .OnDelete(DeleteBehavior.SetNull);

            //    entity.HasMany(x => x.ProductsSold)
            //          .WithOne(x => x.Seller)
            //          .HasForeignKey(x => x.SellerId)
            //          .OnDelete(DeleteBehavior.Restrict);
            //});

            modelBuilder.Entity<Product>(entity =>
            {
                entity
                    .HasOne(e => e.Seller)
                    .WithMany(s => s.ProductsSold)
                    .HasForeignKey(e => e.SellerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                     .HasOne(e => e.Buyer)
                     .WithMany(b => b.ProductsBought)
                     .HasForeignKey(e => e.BuyerId)
                     .IsRequired(false)
                     .OnDelete(DeleteBehavior.SetNull);

            });
        }
    }
}
