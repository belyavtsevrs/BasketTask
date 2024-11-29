using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestBasket.Models;
using TestBasket.Service;

namespace TestBasket.Controllers;
 
public class HomeController : Controller
{ 
    private readonly ProductService productService; 
    public HomeController(ProductService productService)
    { 
        this.productService = productService;
    } 
    public async Task<IActionResult> Index()
    {
        var categories =  await  productService.GetCategoriesAsync();
        var products = await productService.GetProductsAsync(null);
        return View("Index" , (categories,products));
    }
    public async Task<IActionResult> ProductsByCategory(string category)
    {
        var products = await productService.GetProductsAsync(category); 
        var categories = await productService.GetCategoriesAsync();  
        return View("Index", (categories, products)); 
    } 
    
    public async Task<IActionResult> Basket()
    {
        return View(new List<Category>());
    } 
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }
}