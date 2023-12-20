namespace Ztp.Api.Modules;

internal interface IApiModule
{
    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}