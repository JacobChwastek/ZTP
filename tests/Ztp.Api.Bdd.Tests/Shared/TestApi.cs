using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Ztp.Api.Bdd.Tests.Shared;

internal sealed class TestApi: WebApplicationFactory<Program>
{
    public HttpClient Client { get; }

    public TestApi(Action<IServiceCollection?>? services = null)
    {
        Client = WithWebHostBuilder(builder =>
        {
            if (services is not null)
            {
                builder.ConfigureServices(services);
            }
        }).CreateClient();
    }
}