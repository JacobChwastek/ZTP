using System.Net;
using System.Text;
using System.Text.Json;
using Ztp.Web.Models;
using Ztp.Web.ViewModels;

namespace Ztp.Web.Services;

public class ProductApiService(IHttpClientFactory httpClientFactory) : IProductApiService
{
    private const string Prefix = "";
    private readonly HttpClient _httpClient = httpClientFactory.CreateClient("products");

    public async Task<List<Product>?> GetProducts()
    {
        var response = await _httpClient.GetAsync("/api/products");
        var content = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<List<Product>>(content);
    }

    public async Task<Product?> GetProduct(Guid id)
    {
        var response = await _httpClient.GetAsync($"/api/products/{id.ToString()}");
        
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }
        
        var content = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<Product>(content);
    }

    public async Task<ValidationResponse> CreateProduct(CreateProductViewModel productViewModel)
    {
        try
        {
            var response = await _httpClient.PostAsync("/api/products",
                new StringContent(JsonSerializer.Serialize(productViewModel), Encoding.UTF8, "application/json"));
            
            var content = await response.Content.ReadAsStreamAsync();

            return new ValidationResponse
            {
                StatusCode = response.StatusCode,
                ValidationResult = await JsonSerializer.DeserializeAsync<Dictionary<string, List<string>>>(content)
            };
        }
        catch (Exception)
        {
            return new ValidationResponse
            {
                StatusCode = HttpStatusCode.BadRequest,
                ValidationResult = []
            };
        }
    }

    public async Task<ValidationResponse> UpdateProduct(UpdateProductViewModel productViewModel)
    {
        try
        {
            var response = await _httpClient.PutAsync("/api/products",
                new StringContent(JsonSerializer.Serialize(productViewModel), Encoding.UTF8, "application/json"));
            
            var content = await response.Content.ReadAsStreamAsync();

            return new ValidationResponse
            {
                StatusCode = response.StatusCode,
                ValidationResult = await JsonSerializer.DeserializeAsync<Dictionary<string, List<string>>>(content)
            };
        }
        catch (Exception)
        {
            return new ValidationResponse
            {
                StatusCode = HttpStatusCode.BadRequest,
                ValidationResult = []
            };
        }
    }

    public async Task DeleteProduct(Guid id)
    {
        await _httpClient.DeleteAsync($"/api/products/{id.ToString()}");
    }
}