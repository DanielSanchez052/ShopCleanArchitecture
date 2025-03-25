using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Shop.Application.Interfaces;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> NestedIncludes { get; }
    List<string> IncludeStrings { get; }
    Expression<Func<T, object>> OrderBy { get; }
    Expression<Func<T, object>> OrderByDesc { get; }
    int Take { get; }
    int Skip { get; }
    bool IsPagingEnabled { get; }
    bool WithTracking { get; set; }
    bool SplitQuery { get; }

}
