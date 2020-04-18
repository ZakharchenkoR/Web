using Data.DataContext;
using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.DataServices.Base
{
    public class DataServiceBase : IDataService, IDisposable
    {
        #region Private fields
        private readonly IDataSource _dataSource = null;
        #endregion

        #region Ctor
        public DataServiceBase(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }
        #endregion

        #region TextField
        public async Task<int> DeleteTextField(TextField[] entities)
        {
            _dataSource.TextFields.RemoveRange(entities);
            return await _dataSource.SaveChangesAsync();
        }

        public async Task<TextField> GetTextFieldAsync(Guid id)
        {
            return await _dataSource.TextFields.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TextField> GetTextFieldAsync(string codeWord)
        {
            return await _dataSource.TextFields.FirstOrDefaultAsync(x => x.CodeWord == codeWord);

        }

        public async Task<IList<TextField>> GetTextFieldsAsync()
        {
            var items = await GetTextFieldQuery().AsNoTracking().ToListAsync();
            return items;
        }

        private IQueryable<TextField> GetTextFieldQuery()
        {
            IQueryable<TextField> items = _dataSource.TextFields;
            return items;
        }
        #endregion

        #region ServiceItem
        public async Task<int> DeleteServiceItem(ServiceItem[] entities)
        {
            _dataSource.ServiceItems.RemoveRange(entities);
            return await _dataSource.SaveChangesAsync();
        }

        public async Task<ServiceItem> GetServiceItemAsync(Guid id)
        {
            return await _dataSource.ServiceItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<ServiceItem>> GetServiceItemsAsync()
        {
            var items = await GetServiceItemsQuery().AsNoTracking().ToListAsync();
            return items;
        }

        public async Task<int> UpdateServiceItemAsync(ServiceItem entity)
        {
            if (entity.Id != Guid.Empty)
            {
                _dataSource.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                _dataSource.Entry(entity).State = EntityState.Added;
            }
            return await _dataSource.SaveChangesAsync();
        }

        private IQueryable<ServiceItem> GetServiceItemsQuery()
        {
            IQueryable<ServiceItem> items = _dataSource.ServiceItems;
            return items;
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dataSource != null)
                {
                    _dataSource.Dispose();
                }
            }
        }
        #endregion
    }
}
