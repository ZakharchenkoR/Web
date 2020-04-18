using Microsoft.EntityFrameworkCore.Design;

namespace Data.DataContext
{
    public class SQLServerDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            return new AppDbContext("Data Source=localhost;Initial Catalog=WebApp;Integrated Security=SSPI");
        }
    }
}
