using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Data.Common
{
    internal static class ModelBuilderExtensions
    {
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }
        }

        public static void OnDeleteRestrict<TEntity, TRelatedEntity>(this ModelBuilder modelBuilder,
            Expression<Func<TEntity, TRelatedEntity>> navigationProperty,
            Expression<Func<TRelatedEntity, IEnumerable<TEntity>>> navigationCollection)
            where TEntity : class
            where TRelatedEntity : class
        {
            modelBuilder.Entity<TEntity>()
                .HasOne(navigationProperty)
                .WithMany(navigationCollection)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public static void OnDeleteCascade<TEntity, TRelatedEntity>(this ModelBuilder modelBuilder,
            Expression<Func<TEntity, TRelatedEntity>> navigationProperty,
            Expression<Func<TRelatedEntity, IEnumerable<TEntity>>> navigationCollection)
            where TEntity : class
            where TRelatedEntity : class
        {
            modelBuilder.Entity<TEntity>()
                .HasOne(navigationProperty)
                .WithMany(navigationCollection)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
