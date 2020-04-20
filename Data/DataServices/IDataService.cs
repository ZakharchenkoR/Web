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
        Task<int> UpdateRoleAsync(AppRole entity);
        Task<int> DeleteRoleAsync(AppRole[] entities);
        #endregion


        #region AppUser
        Task<IList<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserAsync(Guid id);
        Task<AppUser> GetUserAsync(Common.DataRequest<AppUser> request);
        Task<int> UpdateUserAsync(AppUser entity);
        Task<int> DeleteUserAsync(AppUser[] entities);
        #endregion

        #region AppUserRole
        Task<IList<AppUserRole>> GetUserRoleAsync();
        Task<AppUserRole> GetUserRoleAsync(Guid id);
        Task<int> UpdateUserAsync(AppUserRole entity);
        Task<int> DeleteUserRoleAsync(AppUserRole[] entities);
        #endregion
    }
}
