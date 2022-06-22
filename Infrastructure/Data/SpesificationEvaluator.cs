using System.Linq;
using Core.Entities;
using Core.Spesifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpesificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpesification<TEntity> spec)
        {
            var query = inputQuery;

            if(spec.Criteria != null)
            {
                query.Where(spec.Criteria);
            }

            if(spec.OrderBy != null)
            {
                query.OrderBy(spec.OrderBy);
            }

            if(spec.OrderByDescending != null)
            {
                query.OrderByDescending(spec.OrderByDescending);
            }

            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            return query;
        }
    }
}