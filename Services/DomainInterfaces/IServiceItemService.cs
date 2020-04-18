using Models.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.DomainInterfaces
{
    public interface IServiceItemService
    {
        Task<IList<ServiceItemModel>> GetServiceItemsAsync();
        Task<ServiceItemModel> GetServiceItemAsync(Guid id);
        Task<int> UpdateServiceItemAsync(ServiceItemModel entity);
        Task<int> DeleteServiceItem(ServiceItemModel[] entities);
    }
}
