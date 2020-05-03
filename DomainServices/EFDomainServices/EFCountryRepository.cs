using Data.Common;
using Data.Domain.DataContext;
using Data.Domain.Entities;
using DomainServices.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DomainServices.EFDomainServices
{
    public class EFCountryRepository : ICountryRepository
    {
        private readonly AppDbContext _appDbContext;
        public EFCountryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> DeleteCountryAsync(params Country[] models)
        {
            var entities = models.Select(x => new Country { Id = x.Id }).ToArray();
            _appDbContext.Countries.RemoveRange(entities);
            return await _appDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<IList<Country>> GetCountriesAsync(DataRequest<Country> request = null)
        {
            return await GetCompaniesQuery(request)
                 .AsNoTracking()
                 .ToListAsync()
                 .ConfigureAwait(false);
        }

        public async Task<Country> GetCountryAsync(Guid countryId)
        {
            return await GetCompaniesQuery()
                 .AsNoTracking()
                 .FirstOrDefaultAsync(x => x.Id == countryId)
                 .ConfigureAwait(false);
        }

        public async Task<int> UpdateCountryAsync(Country model)
        {
            _appDbContext.Entry(model).State = model.Id == Guid.Empty ? EntityState.Added : EntityState.Modified;
            return await _appDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        private IQueryable<Country> GetCompaniesQuery(DataRequest<Country> request = null)
        {
            request = request ?? new DataRequest<Country>();

            IQueryable<Country> items = _appDbContext.Countries;

            // Query
            if (!string.IsNullOrEmpty(request.Query))
            {
                string query = request.Query.ToLower();
                items = items.Where(country => country.Name.Contains(query));
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
