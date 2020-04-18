using Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.DataServices.IDataServices
{
    public interface IServiceItemRepository
    {
        Task<IList<ServiceItem>> GetServiceItemsAsync();
        Task<ServiceItem> GetServiceItemAsync(Guid id);
        Task<int> UpdateServiceItemAsync(ServiceItem entity);
        Task<int> DeleteServiceItem(ServiceItem[] entities);
    }
}
