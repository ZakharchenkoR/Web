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

        #region AppRole
        public async Task<IList<AppRole>> GetRoleAsync()
        {
            var items = await GetAppRolesQuery().AsNoTracking().ToListAsync();
            return items;
        }

        public async Task<AppRole> GetRoleAsync(Guid id)
        {
            return await _dataSource.AppRoles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateRoleItemAsync(AppRole entity)
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

        public async Task<int> DeleteRoleField(AppRole[] entities)
        {
            _dataSource.AppRoles.RemoveRange(entities);
            return await _dataSource.SaveChangesAsync();
        }

        private IQueryable<AppRole> GetAppRolesQuery()
        {
            IQueryable<AppRole> items = _dataSource.AppRoles;
            return items;
        }
        #endregion

        #region AppUser
        public async Task<IList<AppUser>> GetUserAsync()
        {
            var items = await GetAppUsersQuery().AsNoTracking().ToListAsync();
            return items;
        }

        public async Task<AppUser> GetUserAsync(Guid id)
        {
            return await _dataSource.AppUsers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateUserItemAsync(AppUser entity)
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

        public async Task<int> DeleteUserField(AppUser[] entities)
        {
            _dataSource.AppUsers.RemoveRange(entities);
            return await _dataSource.SaveChangesAsync();
        }


        private IQueryable<AppUser> GetAppUsersQuery()
        {
            IQueryable<AppUser> items = _dataSource.AppUsers
                .Include(appUser => appUser.Role);
            return items;
        }
        #endregion

        #region AppUserRole
        public async Task<IList<AppUserRole>> GetUserRoleAsync()
        {
            var items = await GetAppUserRolesQuery().AsNoTracking().ToListAsync();
            return items;
        }

        public async Task<AppUserRole> GetUserRoleAsync(Guid id)
        {
            return await _dataSource.AppUserRoles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateUserItemAsync(AppUserRole entity)
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

        public async Task<int> DeleteUserRoleField(AppUserRole[] entities)
        {
            _dataSource.AppUserRoles.RemoveRange(entities);
            return await _dataSource.SaveChangesAsync();
        }

        private IQueryable<AppUserRole> GetAppUserRolesQuery()
        {
            IQueryable<AppUserRole> items = _dataSource.AppUserRoles;
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
