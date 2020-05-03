using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Domain.DataContext
{
    public class SQLAppDbContexFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionBilder = new DbContextOptionsBuilder<AppDbContext>();
            optionBilder.UseSqlServer("Server=DESKTOP-BMVLIVM;Database=PhoneShop;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new AppDbContext(optionBilder.Options);
        }
    }
}
