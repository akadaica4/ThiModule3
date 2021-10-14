using Cakes_Management.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cakes_Management.Contexts
{
    public class CakesManegementDBContext : DbContext
    {
        public CakesManegementDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cake> Cakes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedingCategory(modelBuilder);
        }
        private void SeedingCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Bánh Kem"
                }, new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Bánh Bao"
                }, new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Bánh Trung Thu"
                }, new Category()
                {
                    CategoryId = 4,
                    CategoryName = "Bánh Chưng"
                }, new Category()
                {
                    CategoryId = 5,
                    CategoryName = "Bánh ngọt"
                });
        }
    }
}
