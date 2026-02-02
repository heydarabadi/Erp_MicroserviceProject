using System.Linq.Expressions;

namespace Shared.Application.Specifications;

public abstract class Specification<T>
{
    public abstract Expression<Func<T, bool>> ToExpression();

    public bool IsSatisfiedBy(T entity)
    {
        return ToExpression().Compile()(entity);
    }

    // عملگر AND
    public Specification<T> And(Specification<T> specification)
    {
        return new AndSpecification<T>(this, specification);
    }

    // عملگر OR
    public Specification<T> Or(Specification<T> specification)
    {
        return new OrSpecification<T>(this, specification);
    }

    // عملگر NOT
    public Specification<T> Not()
    {
        return new NotSpecification<T>(this);
    }
}
