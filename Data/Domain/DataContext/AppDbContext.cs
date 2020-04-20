using Data.DataServices;
using Data.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.DataContext
{
    public class AppDbContext : DbContext, IDataSource
    {
        private readonly string _connectionString = null;

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.OnDeleteRestrict<AppUser, AppRole>(x => x.Role, x => x.Users);

            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = new Guid("389447a5-6944-410a-8963-d966b1164fa2"),
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = new Guid("d84014c0-b6db-4d6c-899d-5678d6df922a"),
                Name = "admin",
                NormalizedName = "ADMIN",
                Email = "superzaec22@gmail.com",
                NormalizedEmail = "SUPERZAEC22@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "superpassword"),
            });

            modelBuilder.Entity<AppUserRole>().HasData(new AppUserRole
            {
                Id = new Guid ("c2487303-39dc-4b9b-9437-811ce2656edb"),
                UserId = new Guid("d84014c0-b6db-4d6c-899d-5678d6df922a"),
                RoleId = new Guid("389447a5-6944-410a-8963-d966b1164fa2")
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("b1fc43ca-5742-4283-87fb-474ff1c06128"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("091a9051-3f71-4782-b1d1-c8da75e6629a"),
                CodeWord = "PageServices",
                Title = "Наши услуги"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("ebc491bb-ff1a-4c77-acf4-d49358802e6d"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });
        }
    }
}
