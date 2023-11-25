using Ztp.Domain.Products;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace Ztp.Domain.Bdd.Tests.Steps;

[Binding]
public sealed class ProductsStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;
    private readonly FeatureContext _featureContext;
    private readonly List<Product> _products = new();

    public ProductsStepDefinitions(ScenarioContext scenarioContext, FeatureContext featureContext)
    {
        _scenarioContext = scenarioContext;
        _featureContext = featureContext;
    }

    [Given(@"I have an empty product list")]
    public void GivenIHaveAnEmptyProductIst()
    {
        _products.Clear();
    }
    
    
    [Given(@"I have product with following parameters")]
    public void GivenIHaveProductWithFollowingParameters(Table table)
    {
        var (name, description, price, currencyInput, quantity) = table.CreateInstance<ProductDto>();
        
        Enum.TryParse<Currency>(currencyInput, out var currency);
        
        try
        {
            var product = new Product();
            product.UpdateProductDetails(name, description, new Money(price, currency), quantity);
            
            _scenarioContext.Add(nameof(Product), product);
        }
        catch (Exception e)
        {
            _scenarioContext.Add(nameof(Exception), e);
        }
    }

    [When(@"I create new product with parameters \((.*), (.*), (.*), (.*), (.*)\)")]
    public void WhenCreatingNewProductWithParameters(string name, string description, decimal price, string currencyInput, int quantity)
    {
        Enum.TryParse<Currency>(currencyInput, out var currency);

        try
        {
            var product = new Product();
            product.UpdateProductDetails(name, description, new Money(price, currency), quantity);
            _scenarioContext.Add(nameof(Product), product);
        }
        catch (Exception e)
        {
            _scenarioContext.Add(nameof(Exception), e);
        }
    }


    [Then(@"product version is (.*)")]
    public void ThenProductVersionIs(int version)
    {
        var product = _scenarioContext.Get<Product>(nameof(Product));
        
        Assert.Equal(version, product.Version);
    }

    [Then(@"product details are valid \((.*), (.*), (.*), (.*), (.*)\)")]
    public void ThenProductDetailsAreValid(string name, string description, decimal price, string currency, int quantity)
    {
        var product = _scenarioContext.Get<Product>(nameof(Product));

        var productDetails = product.Details;
        
        Assert.Equal(name, productDetails.Name);
        Assert.Equal(description, productDetails.Description);
        Assert.Equal(price, productDetails.Price.Amount);
        Assert.Equal(quantity, (int)productDetails.InventoryQuantity);
        Assert.Equal(1, product.Version);
        Assert.False(product.IsDeleted);
    }

    [Then(@"a ""(.*)"" should be thrown")]
    public void ThenAShouldBeThrown(string expectedExceptionName)
    {
        var expectedException = _scenarioContext.Get<Exception>(nameof(Exception));
        
        Assert.Equal(expectedExceptionName, expectedException.GetType().Name);
    }

    [When(@"I update product details with following parameters")]
    public void WhenIUpdateProductDetailsWithFollowingParameters(Table table)
    {
        var (name, description, price, currencyInput, quantity) = table.CreateInstance<ProductDto>();
        
        Enum.TryParse<Currency>(currencyInput, out var currency);
        
        var product = _scenarioContext.Get<Product>(nameof(Product));
        
        product.UpdateProductDetails(name, description, new Money(price, currency), quantity);
        
        _scenarioContext.Set(product, nameof(Product));
    }

    [Then(@"I have unavailable product")]
    public void ThenIHaveUnavailableProduct()
    {
        var product = _scenarioContext.Get<Product>(nameof(Product));
        
        Assert.False(product.Details.Availability);
    }

    [Then(@"product changelog contains changes")]
    public void ThenProductChangelogContainsChanges(Table table)
    {
        var (name, description, price, currencyInput, quantity) = table.CreateInstance<ProductDto>();
        
        Enum.TryParse<Currency>(currencyInput, out var currency);

        var product = _scenarioContext.Get<Product>(nameof(Product));
        

        var actualProductDetails = new ProductDetails
        {
            Availability = quantity > 0,
            Description = description,
            Name = name,
            Price = new Money(price, currency),
            InventoryQuantity = quantity
        };

        Assert.Equal( 2, product.Changelog.Count);
        Assert.Contains(product.Changelog, details => details == actualProductDetails);
    }
}


class ProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; }
    public int Quantity { get; set; }

    public void Deconstruct(out string name, out string description, out decimal price, out string currency, out int quantity)
    {
        name = Name;
        description = Description;
        price = Price;
        currency = Currency;
        quantity = Quantity;
    }
}