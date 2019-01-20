using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ParsingStore_App.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ParsingStore_App.DAL
{
    public class ProductContext : DbContext
    {

        public ProductContext() : base("ProductContext")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Racket> Rackets { get; set; }
        public DbSet<Shoes> Shoes { get; set; }
        public DbSet<T_Shirt> T_Shirts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}