using System.Net;

namespace Ztp.Web.Services;

public record ValidationResponse
{
    public HttpStatusCode StatusCode { get; init; }
    public Dictionary<string, List<string>> ValidationResult { get; init; } = new();
}