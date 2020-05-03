using DomainServices.ServiceInterfaces;

namespace DomainServices.Common
{
    public interface IDataManager
    {
        IManufacturerRepository ManufacturerRepository { get; }
        ICountryRepository CountryRepository { get; }
        IModelRepository ModelRepository { get; }
    }
}
