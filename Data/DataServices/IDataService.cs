using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.DataServices
{
    public interface IDataService : IDisposable
    {
        #region ServiceItem
        Task<IList<ServiceItem>> GetServiceItemsAsync();
        Task<ServiceItem> GetServiceItemAsync(Guid id);
        Task<int> UpdateServiceItemAsync(ServiceItem entity);
        Task<int> DeleteServiceItem(ServiceItem[] entities);
        #endregion

        #region TextField
        Task<IList<TextField>> GetTextFieldsAsync();
        Task<TextField> GetTextFieldAsync(Guid id);
        Task<TextField> GetTextFieldAsync(string codeWord);
        Task<int> DeleteTextField(TextField[] entities);
        #endregion

        #region AppRole
        Task<IList<AppRole>> GetRoleAsync();
        Task<AppRole> GetRoleAsync(Guid id);
        Task<int> UpdateRoleItemAsync(AppRole entity);
        Task<int> DeleteRoleField(AppRole[] entities);
        #endregion


        #region AppUser
        Task<IList<AppUser>> GetUserAsync();
        Task<AppUser> GetUserAsync(Guid id);
        Task<int> UpdateUserItemAsync(AppUser entity);
        Task<int> DeleteUserField(AppUser[] entities);
        #endregion

        #region AppUserRole
        Task<IList<AppUserRole>> GetUserRoleAsync();
        Task<AppUserRole> GetUserRoleAsync(Guid id);
        Task<int> UpdateUserItemAsync(AppUserRole entity);
        Task<int> DeleteUserRoleField(AppUser[] entities);
        #endregion
    }
}
