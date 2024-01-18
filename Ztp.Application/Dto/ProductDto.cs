namespace Ztp.Application.Dto;

public record ProductDto
{
    public required Guid ProductId { get; init; }
    public required ProductDetailsDto Details { get; init; }
    public required DateTime CreatedAt { get; init; }
    public required DateTime UpdateAt { get; init; }
}