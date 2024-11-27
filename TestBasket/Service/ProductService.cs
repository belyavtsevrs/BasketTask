﻿using System.Text;
using System.Text.Json;
using TestBasket.Components;
using TestBasket.Models;

namespace TestBasket.Service;

public class ProductService
{
    private readonly DataFetch _dataFetch;

    public ProductService(DataFetch dataFetch)
    {
        _dataFetch = dataFetch;
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
        
        if (categories == null || category == string.Empty)
        {
            return categories;
        }
        return categories
            .Where(p => p.IdCategory == category)
            .ToList();
        return categories;
    }
}