using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Data.Domain.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>().HasData(new List<Manufacturer>
            {
                new Manufacturer {Id = new System.Guid("c35be0f5-53b5-477c-9bc8-b54c639e6995"), Name = "Apple"},
                new Manufacturer {Id = new System.Guid("eeb2bbef-b79b-4581-8192-4e0e317c062a"), Name = "Google"}
            });

            modelBuilder.Entity<Phone>().HasData(new List<Phone>
            {
                new Phone 
                {
                    Id = new System.Guid("a4cee576-8f90-4dbf-b1b4-9e9761a5976f"),
                    Name = "Pixel 2XL",
                    ManufacturerId = new System.Guid("eeb2bbef-b79b-4581-8192-4e0e317c062a"),
                    Count = 100
                },
                new Phone
                {
                    Id = new System.Guid("755d18ca-2cb5-435c-82b8-60c2639f59df"),
                    Name = "Pixel 4",
                    ManufacturerId = new System.Guid("eeb2bbef-b79b-4581-8192-4e0e317c062a"),
                    Count = 100
                },
                new Phone
                {
                    Id = new System.Guid("c35be0f5-53b5-477c-9bc8-b54c639e6995"),
                    Name = "Iphone 6",
                    ManufacturerId = new System.Guid("eeb2bbef-b79b-4581-8192-4e0e317c062a"),
                    Count = 100
                }
            });
        }
    }
}
