using Microsoft.EntityFrameworkCore;
using Nlayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>().HasKey(c => c.Id).HasName("CategoryId");

            //Toplu olarak hepsini okur. 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //Tek tek okur.
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            {
                Id = 1,
                Color ="Red",
                Height = 100,
                Width = 200,
                ProductId = 1
            },
            new ProductFeature()
            {
                Id = 2,
                Color = "Blue",
                Height = 300,
                Width = 500,
                ProductId = 2
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
