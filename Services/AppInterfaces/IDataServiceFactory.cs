using Data.DataServices;

namespace Services.AppInterfaces
{
    public interface IDataServiceFactory
    {
        IDataService CreateDataService();
    }
}
