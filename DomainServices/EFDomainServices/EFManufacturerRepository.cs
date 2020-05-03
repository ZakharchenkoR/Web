using Data.Common;
using Data.Domain.DataContext;
using Data.Domain.Entities;
using DomainServices.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainServices.EFDomainServices
{
    public class EFManufacturerRepository : IManufacturerRepository
    {
        private readonly AppDbContext _appDbContext;

        public EFManufacturerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<int> DeleteManufacturerAsync(params Manufacturer[] models)
        {
            var entities = models.Select(x => new Manufacturer { Id = x.Id }).ToArray();
            _appDbContext.Manufacturers.RemoveRange(entities);
            return await _appDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<Manufacturer> GetManufacturerAsync(Guid manufacturerId)
        {
            return await GetCompaniesQuery()
              .AsNoTracking()
              .FirstOrDefaultAsync(x => x.Id == manufacturerId)
              .ConfigureAwait(false);
        }

        public async Task<IList<Manufacturer>> GetManufacturersAsync(DataRequest<Manufacturer> request = null)
        {
            return await GetCompaniesQuery(request)
               .AsNoTracking()
               .ToListAsync()
               .ConfigureAwait(false);
        }

        public async Task<int> UpdateManufacturerAsync(Manufacturer model)
        {
            _appDbContext.Entry(model).State = model.Id == Guid.Empty ? EntityState.Added : EntityState.Modified;
            return await _appDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        private IQueryable<Manufacturer> GetCompaniesQuery(DataRequest<Manufacturer> request = null)
        {
            request = request ?? new DataRequest<Manufacturer>();

            IQueryable<Manufacturer> items = _appDbContext.Manufacturers.Include(manufacturer => manufacturer.Country);

            // Query
            if (!string.IsNullOrEmpty(request.Query))
            {
                string query = request.Query.ToLower();
                items = items.Where(manufacturer => manufacturer.Name.Contains(query));
            }

            // Where
            if (request.Where != null)
            {
                items = items.Where(request.Where);
            }

            // Order By
            if (request.OrderBy != null)
            {
                items = items.OrderBy(request.OrderBy);
            }
            if (request.OrderByDesc != null)
            {
                items = items.OrderByDescending(request.OrderByDesc);
            }

            return items;
        }
    }
}
