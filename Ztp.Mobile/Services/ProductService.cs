using System.Text;
using System.Text.Json;
using Ztp.Mobile.Models;

namespace Ztp.Mobile.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "http://10.0.2.2:5015";

    public ProductService()
    {
        var httpClientHandler = new HttpClientHandler();
        httpClientHandler.ServerCertificateCustomValidationCallback = (_, _, chain, errors) => true;
        _httpClient = new HttpClient(httpClientHandler);
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/api/products");

            if (!response.IsSuccessStatusCode) 
                return new List<Product>();
            
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Product>>(content);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Product> GetProductAsync(Guid productId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/api/products/{productId}");

            if (!response.IsSuccessStatusCode) 
                return new Product();
            
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Product>(content);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task UpdateProductAsync(UpdateProductRequest productRequest)
    {
       await _httpClient.PutAsync($"{BaseUrl}/api/products", new StringContent(JsonSerializer.Serialize(productRequest), Encoding.UTF8, "application/json"));
    }

    public async Task<bool> DeleteProductAsync(Guid productId)
    {
        try
        {
            await _httpClient.DeleteAsync($"{BaseUrl}/api/products/{productId}");
        }
        catch (Exception)
        {
            return false;
        }

        return true;
    }

    public async Task AddProductAsync(CreateProduct productRequest)
    {
        try
        {
            await _httpClient.PostAsync($"{BaseUrl}/api/products", new StringContent(JsonSerializer.Serialize(productRequest), Encoding.UTF8, "application/json"));
        }
        catch (Exception)
        {
            throw new Exception("Error while adding product");
        }
    }
}

public class UpdateProductRequest
{
    public Guid Id { get;  set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Currency { get; set; }
    public int Quantity { get; set; }
}