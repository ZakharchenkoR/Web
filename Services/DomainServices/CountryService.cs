using Data.Common;
using Data.Domain.Entities;
using DomainServices.Common;
using Models.Models;
using Services.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.DomainServices
{
    public class CountryService : ICountryService
    {
        private readonly IDataManager _dataManager;
        public CountryService (IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<int> DeleteCountryAsync(params CountryModel[] models)
        {
            var entities = models.Select(x => new Country { Id = x.Id }).ToArray();
            return await _dataManager.CountryRepository.DeleteCountryAsync(entities);
        }

        public async Task<IList<CountryModel>> GetCountriesAsync(DataRequest<Country> request = null)
        {
            var entities = await _dataManager.CountryRepository.GetCountriesAsync(request);
            return entities.Select(CreateCountryModel).ToList();
        }

        public async Task<CountryModel> GetCountryAsync(Guid countryId)
        {
            var item = await _dataManager.CountryRepository.GetCountryAsync(countryId);
            return CreateCountryModel(item);
        }

        public async Task<int> UpdateCountryAsync(CountryModel model)
        {
            var entity = model.IsNew ? new Country() : await _dataManager.CountryRepository.GetCountryAsync(model.Id);
            UpdateCountryEntity(entity, model);
            int affectedRows = await _dataManager.CountryRepository.UpdateCountryAsync(entity);
            return affectedRows;
        }

        private CountryModel CreateCountryModel(Country country)
        {
            if(country == null)
            {
                return null;
            }

            var countryModel = new CountryModel
            {
                Id = country.Id,
                Name = country.Name
            };

            return countryModel;
        }

        private void UpdateCountryEntity(Country entity, CountryModel model)
        {
            entity.Name = model.Name;
        }
    }
}
