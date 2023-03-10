using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            // Filtering
            if (spec.Criteria != null) query = query.Where(spec.Criteria);

            // Sorting
            if (spec.OrderBy != null) query = query.OrderBy(spec.OrderBy);
            if (spec.OrderByDescending != null) query = query.OrderByDescending(spec.OrderByDescending);

            // Apply pagination
            if (spec.IsPagingEnabled) query = query.Skip(spec.Skip).Take(spec.Take);

            // Include sub entities
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            
            return query;
        }
    }
}