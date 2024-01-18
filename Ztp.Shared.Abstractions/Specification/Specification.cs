using System.Linq.Expressions;

namespace Ztp.Shared.Abstractions.Specification;

public abstract class Specification<T> : ISpecification<T>
{
    protected abstract Expression<Func<T, bool>> AsPredicateExpression();

    public bool IsSatisfiedBy(T entity)
    {
        return AsPredicateExpression().Compile().Invoke(entity);
    }

    public static implicit operator Expression<Func<T, bool>>(Specification<T> specification)
    {
        return specification.AsPredicateExpression();
    }
}