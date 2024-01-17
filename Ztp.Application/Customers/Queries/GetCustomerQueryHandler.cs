using MediatR;
using Ztp.Application.Dto;

using Ztp.Projections.Repositories;

namespace Ztp.Application.Customers.Queries;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomerDto>
{
    private readonly ICustomerRepository _customerRepository;
    
    public GetCustomerQueryHandler(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<CustomerDto> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdAsync(request.Id, cancellationToken);

        if (customer is null)
        {
            return null;
        }
        
        return new CustomerDto
        {
            Id = customer.Id,
            Name = customer.Name
        };
    }
}