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
    }
}
