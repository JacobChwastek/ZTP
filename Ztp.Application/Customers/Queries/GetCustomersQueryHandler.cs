using MediatR;
using Ztp.Application.Dto;
using Ztp.Projections.Repositories;

namespace Ztp.Application.Customers.Queries;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerDto>>
{
    private readonly ICustomerRepository _customerRepository;

    public GetCustomersQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<List<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _customerRepository.GetAsync(cancellationToken);

        return customers.Select(x => new CustomerDto
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();
    }
}