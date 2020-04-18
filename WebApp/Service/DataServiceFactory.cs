using Data.DataServices;
using Data.DataServices.Base;
using Services.AppInterfaces;
using WebApp.AppConfig;

namespace WebApp.Service
{
    public class DataServiceFactory : IDataServiceFactory
    {
        public IDataService CreateDataService()
        {
            return new SQLServerDataService(Config.ConnectionString);
        }
    }
}
