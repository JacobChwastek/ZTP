using Ztp.Shared.Abstractions.Exceptions;

namespace Ztp.Domain.Products.Exceptions;

public class InvalidReviewStarsException(): DomainException("Stars can be between 1 and 5");