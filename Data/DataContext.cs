using Microsoft.EntityFrameworkCore;
using System;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().ToTable("Products");
            modelBuilder.Entity<Categories>().ToTable("Categories");
        }   
    }
}
