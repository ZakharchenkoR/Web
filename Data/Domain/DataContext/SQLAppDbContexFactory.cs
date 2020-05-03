using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Domain.DataContext
{
    public class SQLAppDbContexFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionBilder = new DbContextOptionsBuilder<AppDbContext>();
            optionBilder.UseSqlServer("Data Source=localhost;Initial Catalog=PhoneShop;Integrated Security=SSPI");
            return new AppDbContext(optionBilder.Options);
        }
    }
}
