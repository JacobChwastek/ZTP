using MediatR;
using Ztp.Application.Dto;

namespace Ztp.Application.Customers.Queries;

public record GetCustomerQuery(Guid Id): IRequest<CustomerDto>;