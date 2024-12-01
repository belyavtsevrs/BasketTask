using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestBasket.Models;
using TestBasket.repository;
using TestBasket.Service;

namespace TestBasket.Controllers;
 
public class HomeController : Controller
{ 
    private readonly ProductService productService;
    private readonly InMemoryBasketRepository inMemoryBasketRepository;
    public HomeController(ProductService productService,InMemoryBasketRepository inMemoryBasketRepository)
    { 
        this.productService = productService;
        this.inMemoryBasketRepository = inMemoryBasketRepository;
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
        List<Product> productsBasket = inMemoryBasketRepository.findAllProducts(); 
        return View(productsBasket);
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View();
    }
}