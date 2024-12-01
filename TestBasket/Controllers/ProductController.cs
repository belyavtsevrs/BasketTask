using Microsoft.AspNetCore.Mvc;
using TestBasket.Models;
using TestBasket.repository;
using TestBasket.Service;

namespace TestBasket.Controllers;
 
[Route("product")]
public class ProductController : Controller
{
    private readonly ProductService _productService; 
    public ProductController(ProductService productService)
    {
        _productService = productService;  
    } 
    public async Task<IActionResult> ProductInfo()
    {
        return View(); 
    }
    [HttpGet("{idProduct}")]
    public async Task<IActionResult> ProductInfo(string idProduct)
    { 
        var product = await _productService.GetProductById(idProduct); 
        return View("ProductInfo", product);
    }

    [HttpPost("add-product")]
    public IActionResult AddProduct(Product product)
    { 
        _productService.addProduct(product); 
        return RedirectToAction("Index", "Home");
    }
}