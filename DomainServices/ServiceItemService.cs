using Data.Domain.Entities;
using Models.Models;
using Services.AppInterfaces;
using Services.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainServices
{
    public class ServiceItemService : IServiceItemService
    {
        private readonly IDataServiceFactory _dataServiceFactory;

        public ServiceItemService(IDataServiceFactory dataServiceFactory)
        {
            _dataServiceFactory = dataServiceFactory;
        }

        public async Task<int> DeleteServiceItem(ServiceItemModel[] entities)
        {
            using (var dataService = _dataServiceFactory.CreateDataService())
            {
                var items = entities.Select(item => new ServiceItem { Id = item.Id }).ToArray();
                int affectedRows = await dataService.DeleteServiceItem(items);
                return affectedRows;
            }
        }

        public async Task<ServiceItemModel> GetServiceItemAsync(Guid id)
        {
            using (var dataService = _dataServiceFactory.CreateDataService())
            {
                var entity = await dataService.GetServiceItemAsync(id);
                return CreateModel(entity);
            }
        }

        public async Task<IList<ServiceItemModel>> GetServiceItemsAsync()
        {
            using (var dataService = _dataServiceFactory.CreateDataService())
            {
                var models = new List<ServiceItemModel>();
                var entities = await dataService.GetServiceItemsAsync();
                foreach (var entity in entities)
                {
                    var model = CreateModel(entity);
                    models.Add(model);
                }
                return models;
            }
        }

        public async Task<int> UpdateServiceItemAsync(ServiceItemModel entity)
        {
            using (var dataService = _dataServiceFactory.CreateDataService())
            {
                var item = entity.Id != Guid.Empty ? await dataService.GetServiceItemAsync(entity.Id) : new ServiceItem();
                UpdateEntity(item, entity);
                int affectedRows = await dataService.UpdateServiceItemAsync(item);
                return affectedRows;
            }
        }

        private ServiceItemModel CreateModel(ServiceItem entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new ServiceItemModel
            {
                Id = entity.Id,
                DateAdded = entity.DateAdded,
                Description = entity.Description,
                Keywords = entity.Keywords,
                MetaTitle = entity.MetaTitle,
                Subtitle = entity.Subtitle,
                Text = entity.Text,
                Title = entity.Title,
                TitleImagePath = entity.TitleImagePath
            };
        }

        private void UpdateEntity(ServiceItem entity, ServiceItemModel model)
        {
            entity.TitleImagePath = model.TitleImagePath;
            entity.Title = model.Title;
            entity.Text = model.Text;
            entity.Subtitle = model.Subtitle;
            entity.MetaTitle = model.MetaTitle;
            entity.Keywords = model.Keywords;
            entity.Description = model.Description;
            entity.DateAdded = model.DateAdded;
        }
    }
}
