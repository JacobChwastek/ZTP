using Microsoft.Extensions.DependencyInjection;
using Ztp.Api.Bdd.Tests.Shared;
using Ztp.Domain.Repositories;

namespace Ztp.Api.Bdd.Tests.Steps;

[Binding]
public class ProductsSteps
{
    private readonly TestApi _testApi;

    public ProductsSteps()
    {
        _testApi = new TestApi(services =>
        {
            services.AddSingleton<IProductRepository, TestProductRepository>();
        });
    }

    [Given(@"the API does not require authorization,")]
    public void GivenTheApiDoesNotRequireAuthorization()
    {
        ScenarioContext.StepIsPending();
    }

    [When(@"I send a GET request to ""(.*)"",")]
    public async Task WhenISendAgetRequestTo(string p0)
    {
        var response = await _testApi.Client.GetAsync("/api/products");
        
    }

    [Then(@"I should receive a response with status code (.*),")]
    public void ThenIShouldReceiveAResponseWithStatusCode(int p0)
    {
        ScenarioContext.StepIsPending();
    }

    [Then(@"the response should contain the created product details\.")]
    public void ThenTheResponseShouldContainTheCreatedProductDetails()
    {
        ScenarioContext.StepIsPending();
    }
}