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
    public class ManufacturerService : IManufacturerService
    {
        private readonly IDataManager _dataManager;
        public ManufacturerService(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<int> DeleteManufacturerAsync(params ManufacturerModel[] models)
        {
            var entities = models.Select(x => new Manufacturer { Id = x.Id }).ToArray();
            return await _dataManager.ManufacturerRepository.DeleteManufacturerAsync(entities);
        }

        public async Task<ManufacturerModel> GetManufacturerAsync(Guid manufacturerId)
        {
            var item = await _dataManager.ManufacturerRepository.GetManufacturerAsync(manufacturerId);
            return CreateManufacturerModel(item);
        }

        public async Task<IList<ManufacturerModel>> GetManufacturersAsync(DataRequest<Manufacturer> request = null)
        {
            var entities = await _dataManager.ManufacturerRepository.GetManufacturersAsync(request);
            return entities.Select(CreateManufacturerModel).ToList();
        }

        public async Task<int> UpdateManufacturerAsync(ManufacturerModel model)
        {
            var entity = model.IsNew ? new Manufacturer() : await _dataManager.ManufacturerRepository.GetManufacturerAsync(model.Id);
            UpdateManufacturerEntity(entity, model);
            int affectedRows = await _dataManager.ManufacturerRepository.UpdateManufacturerAsync(entity);
            return affectedRows;
        }

        private ManufacturerModel CreateManufacturerModel(Manufacturer manufacturer)
        {
            if (manufacturer == null)
            {
                return null;
            }

            var manufacturerModel = new ManufacturerModel
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name,
                CountryId = manufacturer.CountryId
            };

            if(manufacturer.Country != null)
            {
                manufacturerModel.CountryModel = new CountryModel
                {
                    Id = manufacturer.Country.Id,
                    Name = manufacturer.Country.Name
                };
            }

            return manufacturerModel;
        }

        private void UpdateManufacturerEntity(Manufacturer entity, ManufacturerModel model)
        {
            entity.Name = model.Name;
            entity.CountryId = model.CountryId;
        }
    }
}
