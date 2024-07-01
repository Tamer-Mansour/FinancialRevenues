using System.Linq.Expressions;

namespace FinancialRevenues.Extentions;

public static class QueryableExtensions
{
    public static IQueryable<TEntity> WhereIf<TEntity>(this IQueryable<TEntity> query, bool condition,
        Expression<Func<TEntity, bool>> predicate)
    {
        return condition
            ? query.Where(predicate)
            : query;
    }
    
    public static IQueryable<T> PageBy<T>(this IQueryable<T> query, int skipCount, int maxResultCount)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        return query.Skip(skipCount).Take(maxResultCount);
    }
}