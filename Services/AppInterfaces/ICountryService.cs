using Data.Common;
using Data.Domain.Entities;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.AppInterfaces
{
    public interface ICountryService
    {
        Task<CountryModel> GetCountryAsync(Guid countryId);
        Task<IList<CountryModel>> GetCountriesAsync(DataRequest<Country> request = null);
        Task<int> UpdateCountryAsync(CountryModel model);
        Task<int> DeleteCountryAsync(params CountryModel[] models);
    }
}
