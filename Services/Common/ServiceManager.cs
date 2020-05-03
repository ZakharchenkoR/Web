using Services.DomainInterfaces;

namespace Services.Common
{
    public class ServiceManager : IServiceManager
    {
        public IManufacturerService ManufacturerService { get; }
        public IPhoneService PhoneService { get; }
        public ICountryService CountryService { get; }

        public ServiceManager(IManufacturerService manufacturerService, IPhoneService phoneService, ICountryService countryService)
        {
            ManufacturerService = manufacturerService;
            PhoneService = phoneService;
            CountryService = countryService;
        }
    }
}
