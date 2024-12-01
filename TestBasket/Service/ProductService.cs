using System.Text;
using System.Text.Json;
using TestBasket.Components;
using TestBasket.Models;
using TestBasket.repository;

namespace TestBasket.Service;

public class ProductService
{
    private readonly DataFetch _dataFetch;
    
    private readonly InMemoryBasketRepository _InMemoryBasketRepository;

    public ProductService(DataFetch dataFetch,InMemoryBasketRepository inMemoryBasketRepository)
    {
        _dataFetch = dataFetch;
        _InMemoryBasketRepository = inMemoryBasketRepository;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    { 
        var responseString = await _dataFetch.GetCategoriesAsync();
 
        List<Category> categories = DataProcessor.Categories(responseString);

        return categories;
    }

    public async Task<List<Product>> GetProductsAsync(string category)
    {
        var responseString = await _dataFetch.GetProductsAsync();

        List<Product> categories = DataProcessor.Products(responseString);
        
        if (string.IsNullOrEmpty(category))
        {
            return categories; 
        }
        return categories
            .Where(p => p.IdCategory == category)
            .ToList(); 
    }

    public async Task<Product> GetProductById(string productId)
    { 
        var responseString = await _dataFetch.GetProductsAsync();
        List<Product> categories = DataProcessor.Products(responseString);
        
        return categories
            .Where(x=>x.IdProduct == productId)
            .FirstOrDefault();
    }

    public bool addProduct(Product product)
    { 
        _InMemoryBasketRepository.addProduct(product); 
        return true;
    }
}