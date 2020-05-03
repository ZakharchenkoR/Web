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
    public class EFModelRepository : IModelRepository
    {
        private readonly AppDbContext _appDbContext;

        public EFModelRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> DeleteModelAsync(params Model[] models)
        {
            var entities = models.Select(x => new Model { Id = x.Id }).ToArray();
            _appDbContext.Models.RemoveRange(entities);
            return await _appDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<Model> GetModelAsync(Guid modelId)
        {
            return await GetCompaniesQuery()
               .AsNoTracking()
               .FirstOrDefaultAsync(x => x.Id == modelId)
               .ConfigureAwait(false);
        }

        public async Task<IList<Model>> GetModelsAsync(DataRequest<Model> request = null)
        {
            return await GetCompaniesQuery(request)
               .AsNoTracking()
               .ToListAsync()
               .ConfigureAwait(false);
        }

        public async Task<int> UpdateModelAsync(Model model)
        {
            _appDbContext.Entry(model).State = model.Id == Guid.Empty ? EntityState.Added : EntityState.Modified;
            return await _appDbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        private IQueryable<Model> GetCompaniesQuery(DataRequest<Model> request = null)
        {
            request = request ?? new DataRequest<Model>();

            IQueryable<Model> items = _appDbContext.Models.Include(model => model.Manufacturer);

            // Query
            if (!string.IsNullOrEmpty(request.Query))
            {
                string query = request.Query.ToLower();
                items = items.Where(model => model.Name.Contains(query));
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
