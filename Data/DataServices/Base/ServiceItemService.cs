using Data.DataServices.IDataServices;
using Data.Domain;
using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.DataServices.Base
{
    public class ServiceItemService : IServiceItemRepository
    {
        private readonly AppDbContext _appDbContext;

        public ServiceItemService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> DeleteServiceItem(ServiceItem[] entities)
        {
            _appDbContext.ServiceItems.RemoveRange(entities);
            return await _appDbContext.SaveChangesAsync();
        }

        public async Task<ServiceItem> GetServiceItemAsync(Guid id)
        {
            return await _appDbContext.ServiceItems.FirstOrDefaultAsync(x => x.Id == id);
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
                _appDbContext.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                _appDbContext.Entry(entity).State = EntityState.Added;
            }
            return await _appDbContext.SaveChangesAsync();
        }

        private IQueryable<ServiceItem> GetServiceItemsQuery()
        {
            IQueryable<ServiceItem> items = _appDbContext.ServiceItems;
            return items;
        }
    }
}
