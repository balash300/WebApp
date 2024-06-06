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

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Category>().ToTable("Categories");
        }

        internal async Task FindAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
