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
    public class PhoneService : IPhoneService
    {
        private readonly IDataManager _dataManager;
        public PhoneService(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<int> DeletePhoneModelAsync(params PhoneModel[] models)
        {
            var entities = models.Select(x => new Model { Id = x.Id }).ToArray();
            return await _dataManager.ModelRepository.DeleteModelAsync(entities);
        }

        public async Task<PhoneModel> GetPhoneModelAsync(Guid modelId)
        {
            var item = await _dataManager.ModelRepository.GetModelAsync(modelId);
            return CreatePhoneModel(item);
        }

        public async Task<IList<PhoneModel>> GetPhoneModelsAsync(DataRequest<Model> request = null)
        {
            var entities = await _dataManager.ModelRepository.GetModelsAsync(request);
            return entities.Select(CreatePhoneModel).ToList();
        }

        public async Task<int> UpdatePhoneModelAsync(PhoneModel model)
        {
            var entity = model.IsNew ? new Model() : await _dataManager.ModelRepository.GetModelAsync(model.Id);
            UpdateModelEntity(entity, model);
            int affectedRows = await _dataManager.ModelRepository.UpdateModelAsync(entity);
            return affectedRows;
        }

        private PhoneModel CreatePhoneModel(Model model)
        {
            if (model == null)
            {
                return null;
            }

            var phoneModel = new PhoneModel
            {
                Id = model.Id,
                Name = model.Name,
                ManufacturerId = model.ManufacturerId,
                Price = model.Price,
                Count = model.Count
            };

            if(model.Manufacturer != null)
            {
                phoneModel.ManufacturerModel = new ManufacturerModel
                {
                    Id = model.Manufacturer.Id,
                    Name = model.Manufacturer.Name,
                    CountryId = model.Manufacturer.CountryId
                };
            }

            return phoneModel;
        }

        private void UpdateModelEntity(Model entity, PhoneModel model)
        {
            entity.Name = model.Name;
            entity.ManufacturerId = model.ManufacturerId;
            entity.Price = model.Price;
            entity.Count = model.Count;
        }
    }
}
