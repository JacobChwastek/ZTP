using Ztp.Shared.Abstractions.Shared;

namespace Ztp.Application.Dto;

public record ProductDetailsDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required Money Price { get; set; }
    public required int Quantity { get; set; }
    public bool Availability => Quantity > 0;
}