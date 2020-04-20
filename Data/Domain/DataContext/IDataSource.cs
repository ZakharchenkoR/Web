using Data.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Data.DataContext
{
    public interface IDataSource : IDisposable
    {
        DbSet<TextField> TextFields { get; set; }
        DbSet<ServiceItem> ServiceItems { get; set; }
        DbSet<AppUser> AppUsers { get; set; }
        DbSet<AppRole> AppRoles { get; set; }
        DbSet<AppUserRole> AppUserRoles { get; set; }

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
