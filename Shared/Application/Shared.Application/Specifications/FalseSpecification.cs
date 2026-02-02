using System.Linq.Expressions;

namespace Shared.Application.Specifications;

public sealed class FalseSpecification<T> : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression() => x => false;
}