using Services.DomainInterfaces;

namespace Services.Common
{
    public interface IServiceManager
    {
        IManufacturerService ManufacturerService { get; }
        IPhoneService PhoneService { get; }
        ICountryService CountryService { get; }
    }
}
