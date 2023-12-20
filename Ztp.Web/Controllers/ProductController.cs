using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ztp.Web.Models;
using Ztp.Web.Services;
using Ztp.Web.ViewModels;

namespace Ztp.Web.Controllers;

public class ProductController(IProductApiService productApiService) : Controller
{
    private readonly List<SelectListItem> _currencies =
    [
        new SelectListItem { Text = "PLN", Value = "1" },
        new SelectListItem { Text = "EUR", Value = "2" },
        new SelectListItem { Text = "USD", Value = "3" }
    ];
    
    public async Task<IActionResult> Index()
    {
        try
        {
            var products = await productApiService.GetProducts();

            return View(products);
        }
        catch (Exception)
        {
            return View(new List<Product>());
        }
    }

    [HttpGet("details/{id}")]
    public async Task<IActionResult> Details(Guid id)
    {
        try
        {
            var product = await productApiService.GetProduct(id);

            return View(product);
        }
        catch (Exception)
        {
            return RedirectToAction("Index");
        }
    }
    
    [HttpGet("edit/{id:guid}")]
    public async Task<IActionResult> Edit(Guid id)
    {
        var product = await productApiService.GetProduct(id);
        
        ViewBag.CurrencyList = _currencies;

        if (product is null)
        {
            return RedirectToAction("Index");
        }
        
        return View(new UpdateProductViewModel(product));
    }
    
    [HttpPost("edit/{id:guid}")]
    public async Task<IActionResult> Edit(UpdateProductViewModel updateProduct)
    {
        var validationResponse = await productApiService.UpdateProduct(updateProduct);
        
        switch (validationResponse.StatusCode)
        {
            case HttpStatusCode.OK:
                return RedirectToAction("Index");
            default:
                foreach (var (key, message) in validationResponse.ValidationResult)
                {
                    ModelState.AddModelError(key, string.Join(", ", message));
                }

                break;
        }
        
        ViewBag.CurrencyList = _currencies;
        
        return View(updateProduct);
    }
    
    [HttpGet("delete/{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await productApiService.DeleteProduct(id);
        
        return RedirectToAction("Index");
    }

    [HttpGet("add")]
    public IActionResult Add()
    {
        ViewBag.CurrencyList = _currencies;
        
        return View();
    }

    [HttpPost("add")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(CreateProductViewModel product)
    {
        var validationResponse = await productApiService.CreateProduct(product);

        switch (validationResponse.StatusCode)
        {
            case HttpStatusCode.OK:
                return RedirectToAction("Index");
            default:
                foreach (var (key, message) in validationResponse.ValidationResult)
                {
                    ModelState.AddModelError(key, string.Join(", ", message));
                }

                break;
        }

        ViewBag.CurrencyList = _currencies;
        
        return View(product);
    }
}