using MediatR;
using Ztp.Application.Dto;

namespace Ztp.Application.Customers.Queries;

public record GetCustomersQuery: IRequest<List<CustomerDto>>;