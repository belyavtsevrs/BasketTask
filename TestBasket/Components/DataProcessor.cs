using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using TestBasket.Models;

namespace TestBasket.Components;

public class DataProcessor
{
    public static List<Category> Categories(string responseString)
    {
        try
        {
            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(responseString);

            var categoriesJson = jsonResponse.GetProperty("CategoryList").EnumerateArray();

            return categoriesJson
                .Select(x => new Category()
                {
                    IdCategory = x.GetProperty("idCategory").GetString(),
                    StrCategory = x.GetProperty("strCategory").GetString(),
                    StrCategoryThumb = x.GetProperty("strCategoryThumb").GetString(),
                })
                .ToList();
        }
        catch (Exception e)
        { 
            return new List<Category>(); 
        }
    }

    public static List<Product> Products(string responseString)
    {
        try
        {
            var jsonResponse = JsonSerializer.Deserialize<JsonElement>(responseString);

            var categoriesJson = jsonResponse.GetProperty("ProdList").EnumerateArray();

            return categoriesJson
                .Select(x => new Product()
                {
                    IdCategory = x.GetProperty("idCategory").GetString(),
                    IdProduct = x.GetProperty("idProduct").GetString(),
                    StrProduct = x.GetProperty("strProduct").GetString(),
                    SrtProductThumb = x.GetProperty("srtProductThumb")
                        .EnumerateArray()
                        .Select(y => y.GetProperty("images").GetString())
                        .ToList(),
                    Price = x.GetProperty("Price").GetDecimal(),
                    Curency = x.GetProperty("Curency").GetString(),
                })
                .ToList();
        }
        catch (Exception e)
        {
            return new List<Product>();
        }
    }
}