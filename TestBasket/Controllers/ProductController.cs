using Microsoft.AspNetCore.Mvc;
using TestBasket.Service;

namespace TestBasket.Controllers;


[Route("/product")]
public class ProductController : Controller
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }
    
    /*[HttpGet("details/{idProduct}")]
    public Task<IActionResult> ProductDetails(string idProduct)
    {
        var product = await _productService.get(idProduct);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }*/
}