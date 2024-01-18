namespace Ztp.Shared.Abstractions.Specification;

public interface ISpecification<in T>
{
    public bool IsSatisfiedBy(T entity);
}