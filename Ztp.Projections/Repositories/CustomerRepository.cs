using Microsoft.EntityFrameworkCore;
using Ztp.Projections.Models;

namespace Ztp.Projections.Repositories;

public interface ICustomerRepository
{
    Task<Customer> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<List<Customer>> GetAsync(CancellationToken cancellationToken = default);
    Task AddAsync(Customer customer, CancellationToken cancellationToken = default);
    Task UpdateAsync(Customer customer, CancellationToken cancellationToken = default);
}


public class CustomerRepository: ICustomerRepository
{
    private readonly ProjectionsDbContext _projectionsDbContext;

    public CustomerRepository(ProjectionsDbContext projectionsDbContext)
    {
        _projectionsDbContext = projectionsDbContext;
    }

    public async Task<Customer> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _projectionsDbContext.Customers.SingleOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
    }

    public async Task<List<Customer>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await _projectionsDbContext.Customers.ToListAsync(cancellationToken);
    }

    public Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Customer customer, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}