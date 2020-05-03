using Data.Common;
using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainServices.ServiceInterfaces
{
    public interface ICountryRepository
    {
        Task<Country> GetCountryAsync(Guid countryId);
        Task<IList<Country>> GetCountriesAsync(DataRequest<Country> request = null);
        Task<int> UpdateCountryAsync(Country model);
        Task<int> DeleteCountryAsync(params Country[] models);
    }
}
