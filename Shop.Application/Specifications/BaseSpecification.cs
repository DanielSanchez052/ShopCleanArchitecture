using Microsoft.EntityFrameworkCore.Query;
using Shop.Application.Interfaces;
using System.Linq.Expressions;

namespace Shop.Application.Specifications;

public class BaseSpecification<T> : ISpecification<T>
{
    public Expression<Func<T, bool>> Criteria { get; }
    public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
    public List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> NestedIncludes { get; } = new List<Func<IQueryable<T>, IIncludableQueryable<T, object>>>();
    public List<string> IncludeStrings { get; } = new List<string>();
    public Expression<Func<T, object>> OrderBy { get; private set; }
    public Expression<Func<T, object>> OrderByDesc { get; private set; }
    public int Take { get; private set; }
    public int Skip { get; private set; }
    public bool IsPagingEnabled { get; private set; }
    public bool WithTracking { get; set; }
    public bool SplitQuery { get; private set; }

    public BaseSpecification() { }
    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    protected void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }

    protected virtual void AddNestedInclude(Func<IQueryable<T>, IIncludableQueryable<T, object>> nestedIncludeExpression)
    {
        NestedIncludes.Add(nestedIncludeExpression);
    }

    protected void AddInclude(string IncludeString)
    {
        IncludeStrings.Add(IncludeString);
    }

    protected void AddOrderBy(Expression<Func<T, object>> orderByException)
    {
        OrderBy = orderByException;
    }
    protected void AddOrderByDesc(Expression<Func<T, object>> orderByDescException)
    {
        OrderByDesc = orderByDescException;
    }

    protected void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;
    }

    protected void ApplySplitQuery()
    {
        SplitQuery = true;
    }
}
