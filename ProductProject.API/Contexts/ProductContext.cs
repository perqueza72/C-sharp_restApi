using Microsoft.EntityFrameworkCore;
using ProductProject.API.Models.ProductModel;
using System;

namespace ProductProject.API.Contexts
{
    public class ProductContext : DbContext
    {
        public DbSet<Entities.Product> Products { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entities.Product>()
                 .HasData(
                new Entities.Product()
                {
                    Id = 1,
                    Description = "The one with that big park.",
                    Value = 100,
                    ProductType = ProductType.BIENES,
                    Date = DateTime.UtcNow
                },
                new Entities.Product()
                {
                    Id = 2,
                    Description = "The one with the cathedral that was never really finished."
                    ,
                    Value = 200,
                    ProductType = ProductType.BIENES,
                    Date = DateTime.UtcNow


                },
                new Entities.Product()
                {
                    Id = 3,
                    Description = "The one with that big tower."
                    ,
                    Value = 300,
                    ProductType = ProductType.BIENES
                    ,
                    Date = DateTime.UtcNow
                });

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}

    }
}
