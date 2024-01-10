using Ztp.Domain.Products.Exceptions;

namespace Ztp.Domain.Products;

public record Review
{
    public string Title { get; init; }
    public string Body { get; init; }
    public short Stars { get; init; }

    public Review(string title, string body, short stars)
    {
        if (stars is < 1 or > 5)
        {
            throw new InvalidReviewStarsException();
        }
        
        Title = title;
        Body = body;
        Stars = stars;
    }
};