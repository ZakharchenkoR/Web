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
    public class TextFieldService : ITextFieldService
    {
        private readonly IDataServiceFactory _dataServiceFactory;

        public TextFieldService(IDataServiceFactory dataServiceFactory)
        {
            _dataServiceFactory = dataServiceFactory;
        }

        public async Task<int> DeleteTextField(TextFieldModel[] entities)
        {

            using (var dataService = _dataServiceFactory.CreateDataService())
            {
                var items = entities.Select(item => new TextField { Id = item.Id }).ToArray();
                int affectedRows = await dataService.DeleteTextField(items);
                return affectedRows;
            }
        }

        public async Task<TextFieldModel> GetTextFieldAsync(Guid id)
        {
            using (var dataService = _dataServiceFactory.CreateDataService())
            {
                var entity = await dataService.GetTextFieldAsync(id);
                return CreateModel(entity);
            }
        }

        public async Task<TextFieldModel> GetTextFieldAsync(string codeWord)
        {
            using (var dataService = _dataServiceFactory.CreateDataService())
            {
                var entity = await dataService.GetTextFieldAsync(codeWord);
                return CreateModel(entity);
            }
        }

        public async Task<IList<TextFieldModel>> GetTextFieldsAsync()
        {
            using (var dataService = _dataServiceFactory.CreateDataService())
            {
                var models = new List<TextFieldModel>();
                var entities = await dataService.GetTextFieldsAsync();
                foreach (var entity in entities)
                {
                    var model = CreateModel(entity);
                    models.Add(model);
                }
                return models;
            }
        }

        private TextFieldModel CreateModel(TextField entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new TextFieldModel
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

        private void UpdateEntity(TextField entity, TextFieldModel model)
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
