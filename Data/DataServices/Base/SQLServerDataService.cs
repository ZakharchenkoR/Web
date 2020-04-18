using Data.DataContext;

namespace Data.DataServices.Base
{
    public class SQLServerDataService : DataServiceBase
    {
        public SQLServerDataService(string connectionString)
           : base(new AppDbContext(connectionString))
        {
        }
    }
}
