using DomainServices.ServiceInterfaces;

namespace DomainServices.Common
{
    public class DataManager : IDataManager
    {
        public IManufacturerRepository ManufacturerRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public IModelRepository ModelRepository { get; }

        public DataManager(IManufacturerRepository manufacturerRepository, ICountryRepository countryRepository, IModelRepository modelRepository)
        {
            ModelRepository = modelRepository;
            ManufacturerRepository = manufacturerRepository;
            CountryRepository = countryRepository;
        }
    }
}
