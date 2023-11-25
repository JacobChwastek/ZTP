namespace Ztp.Application.Dto;

public class ProductDto
{
    public required Guid ProductId { get; set; }
    public required ProductDetailsDto Details { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdateAt { get; set; }
    public required int Version { get; set; }
}