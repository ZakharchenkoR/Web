﻿using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Data.Domain.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Model> Models { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new List<Country>
            {
                new Country { Id = new System.Guid("ef87c39b-2cc6-407e-b974-edbcf20781ad"), Name = "China" },
                new Country { Id = new System.Guid("cc61583f-4ebd-4b68-8e41-b56822aec84e"), Name = "USA" },
                new Country { Id = new System.Guid("fb13009a-e4d3-4770-8c77-957e78b61802"), Name = "South Korea" }
            });

            modelBuilder.Entity<Manufacturer>().HasData(new List<Manufacturer>
            {
                new Manufacturer { Id = new System.Guid("62d760f0-648a-4ee0-9923-b63effd17b5b"), CountryId = Country.USA.Id, Name = "Iphone" },
                new Manufacturer { Id = new System.Guid("e8b5a606-0b3a-4a16-b15d-c6855d91a4ef"), CountryId = Country.USA.Id, Name = "Google" },
                new Manufacturer { Id = new System.Guid("f639ccdd-39d5-40b5-98af-d07211f7b61a"), CountryId = Country.China.Id, Name = "Xiaomi" },
                new Manufacturer { Id = new System.Guid("1bea5a7c-03ca-40a4-aad4-7911b69b39fd"), CountryId = Country.China.Id, Name = "Huawei" },
                new Manufacturer { Id = new System.Guid("b12dabf7-4845-4788-b55e-b0d7e3d673fb"), CountryId = Country.SouthKorea.Id, Name = "Samsung" }
            });

            modelBuilder.Entity<Model>().HasData(new List<Model>
            {
                new Model{Id = new System.Guid("a85fbe94-7462-4690-ba65-921cc2b7f4e8"), ManufacturerId = Manufacturer.Google.Id, Name = "Pixel 2XL", Price = 8200, Count = 100},
                new Model{Id = new System.Guid("42be4c1c-d92e-4a54-8103-45b57077b44c"), ManufacturerId = Manufacturer.Google.Id, Name = "Pixel 3XL", Price = 14500, Count = 1000},
                new Model{Id = new System.Guid("e813c617-6724-4bd1-bb36-e9c32b71e7fb"), ManufacturerId = Manufacturer.Google.Id, Name = "Pixel 4", Price = 15500, Count = 1000},
                new Model{Id = new System.Guid("3a5558b7-3f4a-492e-b6fe-5d28c9099b35"), ManufacturerId = Manufacturer.Google.Id, Name = "Pixel 4XL", Price = 17500, Count = 1000},
                new Model{Id = new System.Guid("436b8fe4-69dc-4d84-a30f-1696e4a18f4f"), ManufacturerId = Manufacturer.Iphone.Id, Name = "6", Price = 3500, Count = 1000},
                new Model{Id = new System.Guid("d241ba3b-cb36-4415-829a-451232f78cd1"), ManufacturerId = Manufacturer.Iphone.Id, Name = "6S", Price = 4500, Count = 1000},
                new Model{Id = new System.Guid("2380b3b0-a3e6-46bf-adf7-a8451c62ac15"), ManufacturerId = Manufacturer.Iphone.Id, Name = "8", Price = 8000, Count = 1000},
                new Model{Id = new System.Guid("74ef6172-5389-4470-aea4-b40beb27301f"), ManufacturerId = Manufacturer.Iphone.Id, Name = "X", Price = 14000, Count = 1000},
                new Model{Id = new System.Guid("cebee680-2ebf-4620-8a84-5e40e3b516ec"), ManufacturerId = Manufacturer.Xiaomi.Id, Name = "Mi 9", Price = 9000, Count = 1000},
                new Model{Id = new System.Guid("366d57df-9f01-4ccf-a46f-fbaf0aa7d07d"), ManufacturerId = Manufacturer.Xiaomi.Id, Name = "Mi 10", Price = 25000, Count = 1000},
                new Model{Id = new System.Guid("0b97a35a-d8b7-4704-925a-27cd8a3803a5"), ManufacturerId = Manufacturer.Huawei.Id, Name = "P40 Pro", Price = 28000, Count = 1000},
                new Model{Id = new System.Guid("92d01c5c-5056-49db-a323-a65b1de1b218"), ManufacturerId = Manufacturer.Samsung.Id, Name = "P20 Pro", Price = 32000, Count = 1000}
            });
        }
    }
}
