using Ztp.Shared.Abstractions.Exceptions;

namespace Ztp.Domain.Products;

public record Review
{
    public string Title { get; init; }
    public string Body { get; set; }
    public short Stars { get; set; }

    public Review(string title, string body, short stars)
    {
        if (stars is < 1 or > 5)
        {
            throw new InvalidReviewStars();
        }
        
        Title = title;
        Body = body;
        Stars = stars;
    }
};

public class InvalidReviewStars(): DomainException("Stars can be between 1 and 5");