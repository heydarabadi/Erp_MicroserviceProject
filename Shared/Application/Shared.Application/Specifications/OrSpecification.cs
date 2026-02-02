using System.Linq.Expressions;

namespace Shared.Application.Specifications;

internal class OrSpecification<T> : Specification<T>
{
    private readonly Specification<T> _left;
    private readonly Specification<T> _right;

    public OrSpecification(Specification<T> left, Specification<T> right)
    {
        _left = left;
        _right = right;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = _left.ToExpression();
        var rightExpression = _right.ToExpression();

        var parameter = Expression.Parameter(typeof(T));

        var leftVisitor = new ParameterReplacer(parameter);
        var left = leftVisitor.Visit(leftExpression.Body);

        var rightVisitor = new ParameterReplacer(parameter);
        var right = rightVisitor.Visit(rightExpression.Body);

        return Expression.Lambda<Func<T, bool>>(Expression.OrElse(left, right), parameter);
    }
}