using Microsoft.EntityFrameworkCore;
using SingleGetQuery.DataBase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleGetQuery.DataBase
{
    public class SingleGetQueryDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public SingleGetQueryDbContext(DbContextOptions<SingleGetQueryDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var foodCategoryId = Guid.NewGuid();
            var techniqueCategoryId = Guid.NewGuid();
            var closesCategoryId = Guid.NewGuid();

            modelBuilder.Entity<Product>().HasData(
                new Product[]
                {
                    new Product {Id=Guid.NewGuid(), Name="Apple", Price=10, CategoryId=foodCategoryId},
                    new Product {Id=Guid.NewGuid(), Name="Lemon", Price=30, CategoryId=foodCategoryId},
                    new Product {Id=Guid.NewGuid(), Name="Carrot", Price=9, CategoryId=foodCategoryId},
                    new Product {Id=Guid.NewGuid(), Name="Mango", Price=40, CategoryId=foodCategoryId},
                    new Product {Id=Guid.NewGuid(), Name="Orange", Price=45, CategoryId=foodCategoryId},
                    new Product {Id=Guid.NewGuid(), Name="Phone", Price=1500, CategoryId=techniqueCategoryId},
                    new Product {Id=Guid.NewGuid(), Name="Laptop", Price=2500, CategoryId=techniqueCategoryId},
                    new Product {Id=Guid.NewGuid(), Name ="Xbox", Price=1700, CategoryId=techniqueCategoryId},
                    new Product {Id=Guid.NewGuid(), Name="PlayStation", Price=2000, CategoryId=techniqueCategoryId},
                    new Product {Id=Guid.NewGuid(), Name="TV", Price=2100, CategoryId=techniqueCategoryId},
                });

            modelBuilder.Entity<Category>().HasData(
                new Category[]
                {
                    new Category {Id=foodCategoryId, Name="Food"},
                    new Category {Id=techniqueCategoryId, Name="Technique"},
                    new Category {Id=closesCategoryId, Name="Closes"}
                });
        }
    }
}
