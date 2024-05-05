using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Extensions;

public static class EFCoreContextExtensions
{
    public static IQueryable<TEntity> IncludeAllEntities<TEntity>(
        this DbSet<TEntity> dbSet,
        Expression<Func<TEntity, bool>>? predicate = null) where TEntity : class
    {
        IQueryable<TEntity> query = dbSet;

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        var navigationProperties = typeof(TEntity).GetProperties()
            .Where(p => p.PropertyType.IsClass && p.PropertyType != typeof(string) && !p.PropertyType.IsArray && p.GetMethod != null);

        foreach (var navigationProperty in navigationProperties)
        {
            query = query.Include(navigationProperty.Name);
        }

        return query;
    }
}
