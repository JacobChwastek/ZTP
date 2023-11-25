namespace Ztp.Api.Modules;

public interface IApiModule
{
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}