using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Ztp.Web.Controllers;
using Ztp.Web.Models;
using Ztp.Web.Services;
using Ztp.Web.ViewModels;

namespace Ztp.Web.Unit.Tests;

public class ProductControllerTests
{
    private readonly Mock<IProductApiService> _mockApiService;
    private readonly ProductController _controller;

    public ProductControllerTests()
    {
        _mockApiService = new Mock<IProductApiService>();
        _controller = new ProductController(_mockApiService.Object);
    }

    [Fact]
    public async Task Details_WithExistingId_ReturnsViewWithProduct()
    {
        // Arrange
        var testProductId = Guid.NewGuid();
        var testProduct = new Product
        {
            ProductId = testProductId, ProductDetails = new ProductDetails
            {
                Price = new Money { Amount = 1.0m, Currency = "USD" }, Description = "test", Name = "test",
                Availability = true,
                Quantity = 1000
            },
            Version = 1,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        _mockApiService.Setup(s => s.GetProduct(testProductId)).ReturnsAsync(testProduct);

        // Act
        var result = await _controller.Details(testProductId);

        // Assert
        result.Should().BeOfType<ViewResult>();
        var viewResult = result as ViewResult;
        viewResult?.Model.Should().BeEquivalentTo(testProduct);
    }

    [Fact]
    public async Task Details_WithNonExistingId_ReturnsNotFound()
    {
        // Arrange
        _mockApiService.Setup(s => s.GetProduct(It.IsAny<Guid>())).ReturnsAsync(() => null);

        // Act
        var result = await _controller.Details(Guid.NewGuid());

        // Assert
        result.Should().BeOfType<ViewResult>();
    }

    [Fact]
    public async Task AddPost_WithValidModel_AddsProductAndRedirects()
    {
        // Arrange
        var productViewModel = new CreateProductViewModel
        {
            Currency = 1,
            Description = "test",
            Name = "test",
            Quantity = 100,
            Price = 100
        };
        _mockApiService.Setup(s => s.CreateProduct(productViewModel)).ReturnsAsync(new ValidationResponse
            { ValidationResult = [], StatusCode = HttpStatusCode.Created });

        // Act
        var result = await _controller.Add(productViewModel);

        // Assert
        result.Should().BeOfType<ViewResult>();
    }

    [Fact]
    public async Task AddPost_WithInvalidModel_ReturnsViewWithModel()
    {
        // Arrange
        var productViewModel = new CreateProductViewModel
        {
            Currency = -1,
            Description = "",
            Name = "",
            Quantity = -1,
            Price = -1
        };
        _mockApiService.Setup(s => s.CreateProduct(productViewModel)).ReturnsAsync(new ValidationResponse
        {
            ValidationResult = new Dictionary<string, List<string>>
            {
                { "Name", ["'Name' must not be empty."] },
                { "Description", ["'Description' must not be empty."] },
                { "Price", ["'Price' must be greater than '0'."] },
                { "Quantity", ["'Quantity' must be greater than '0'."] },
                {
                    "Currency", [
                        "'Currency' must not be empty.",
                        "The specified condition was not met for 'Currency'."
                    ]
                }
            },
            StatusCode = HttpStatusCode.Created
        });

        // Act
        var result = await _controller.Add(productViewModel);

        // Assert
        result.Should().BeOfType<ViewResult>();
        _controller.ModelState.Count.Should().Be(5);
        var viewResult = result as ViewResult;
        viewResult?.Model.Should().BeEquivalentTo(productViewModel);
    }
}