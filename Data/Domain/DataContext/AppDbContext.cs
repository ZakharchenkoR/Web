using Data.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.DataContext
{
    public class AppDbContext : IdentityDbContext<IdentityUser>, IDataSource
    {
        private readonly string _connectionString = null;

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<ServiceItem> ServiceItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "389447a5-6944-410a-8963-d966b1164fa2",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "d84014c0-b6db-4d6c-899d-5678d6df922a",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "superzaec22@gmail.com",
                NormalizedEmail = "SUPERZAEC22@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = "d84014c0-b6db-4d6c-899d-5678d6df922a",
                RoleId = "389447a5-6944-410a-8963-d966b1164fa2"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new System.Guid("b1fc43ca-5742-4283-87fb-474ff1c06128"),
                CodeWord = "PageIndex",
                Title = "Главная"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new System.Guid("091a9051-3f71-4782-b1d1-c8da75e6629a"),
                CodeWord = "PageServices",
                Title = "Наши услуги"
            });

            modelBuilder.Entity<TextField>().HasData(new TextField
            {
                Id = new System.Guid("ebc491bb-ff1a-4c77-acf4-d49358802e6d"),
                CodeWord = "PageContacts",
                Title = "Контакты"
            });
        }
    }
}
