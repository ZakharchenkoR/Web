using Data.Common;
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
    public class UserService : IUserService
    {
        private readonly IDataServiceFactory _dataServiceFactory;

        public UserService(IDataServiceFactory dataServiceFactory)
        {
            _dataServiceFactory = dataServiceFactory;
        }

        public async Task<int> DeleteUserAsync(ApplicationUserModel[] entities)
        {
            using (var dataService = _dataServiceFactory.CreateDataService())
            {
                var items = entities.Select(item => new AppUser { Id = item.Id }).ToArray();
                int affectedRows = await dataService.DeleteUserAsync(items);
                return affectedRows;
            }
        }

        public async Task<IList<ApplicationUserModel>> GetUsersAsync()
        {
            using (var dataService = _dataServiceFactory.CreateDataService())
            {
                var models = new List<ApplicationUserModel>();
                var entities = await dataService.GetUsersAsync();
                foreach (var entity in entities)
                {
                    var model = CreateModel(entity);
                    models.Add(model);
                }
                return models;
            }
        }

        public async Task<ApplicationUserModel> GetUserAsync(Guid id)
        {
            using (var dataService = _dataServiceFactory.CreateDataService())
            {
                var entity = await dataService.GetUserAsync(id);
                return CreateModel(entity);
            }
        }

        public async Task<ApplicationUserModel> GetUserAsync(DataRequest<AppUser> request)
        {
            using (var dataService = _dataServiceFactory.CreateDataService())
            {
                var entity = await dataService.GetUserAsync(request);
                return CreateModel(entity);
            }
        }

        public async Task<int> UpdateUserAsync(ApplicationUserModel entity)
        {
            using (var dataService = _dataServiceFactory.CreateDataService())
            {
                var item = entity.Id != Guid.Empty ? await dataService.GetUserAsync(entity.Id) : new AppUser();
                UpdateEntity(item, entity);
                int affectedRows = await dataService.UpdateUserAsync(item);
                return affectedRows;
            }
        }

        private ApplicationUserModel CreateModel(AppUser entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new ApplicationUserModel
            {
                Id = entity.Id,
                Name = entity.Name,
                NormalizedEmail = entity.NormalizedEmail,
                Email = entity.Email,
                EmailConfirmed = entity.EmailConfirmed,
                PasswordHash = entity.PasswordHash,
                NormalizedName = entity.NormalizedName,
            };
        }

        private void UpdateEntity(AppUser entity, ApplicationUserModel model)
        {
            entity.Name = model.Name;
            entity.NormalizedName = model.NormalizedName;
            entity.Email = model.Email;
            entity.NormalizedEmail = model.NormalizedEmail;
            entity.PasswordHash = model.PasswordHash;
            entity.EmailConfirmed = model.EmailConfirmed;
        }
    }
}
