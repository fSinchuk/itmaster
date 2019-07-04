using App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DAL
{
   public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<Products> Products { get; set; }

        // public webstoreContext(DbContextOptions<webstoreContext> options) : base(options) { }

        //public DbSet<ProductCategories> ProductCategories { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<ProductCategories>().HasData(new ProductCategories[] {
        //        new ProductCategories(){ Id=2, Name="Category 1" },
        //        new ProductCategories(){ Id=3, Name="Category 2" },
        //        new ProductCategories(){ Id=4, Name="Category 3" },
        //    });


        //    modelBuilder.Entity<Products>().HasData(new Products[] {
        //        new Products(){ Id=1, Name="Product 1", IsActive=true, CategoryId=1, Price=22.2},
        //        new Products(){ Id=2, Name="Product 2", IsActive=true, CategoryId=2, Price=33.3},
        //        new Products(){ Id=3, Name="Product 3", IsActive=true, CategoryId=3, Price=44.4},
        //    });


        //}
    }
}
