using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extentions
{
    internal static class RepositoryExtension
    {
        public static IQueryable<TEntity> NoTracking<TEntity>(this IQueryable<TEntity> source, bool noTracking = true)
            where TEntity : class
        {
            return noTracking ? source.AsNoTracking() : source;
        }
    }
}