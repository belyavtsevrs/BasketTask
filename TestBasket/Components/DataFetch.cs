using System.Text;
using System.Text.Json;

namespace TestBasket.Components;

public class DataFetch
{
    private readonly HttpClient _httpClient;

    public DataFetch(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<string> GetCategoriesAsync()
    {
        string url = "https://onsite.iteca.kz/exh-prod-category/";

        var requestBody = new
        {
            apiKey = "0KHQtdC60YDQtdGC0L3Ri9C50JrQu9GO0YfQlNC70Y/QotC10YXQl9Cw0LrQsNC30LA=",
            lang = "ru",
            exhibkey = "Kioge 2024",
            companykey = "QUEwMDAwMDAyNzky",
            companyid = "MHhhNzA5MDAxNzlhN2JjY2JmMTFkZDUzMjI5YTYzMzgyMw=="
        };

        var jsonBody = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, content);

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        return responseString;
    }

    public async Task<string> GetProductsAsync()
    {
        string url = "https://onsite.iteca.kz/exh-prod-list/";
        
        var requestBody = new
        {
            apiKey = "0KHQtdC60YDQtdGC0L3Ri9C50JrQu9GO0YfQlNC70Y/QotC10YXQl9Cw0LrQsNC30LA=",
            lang = "ru",
            exhibkey = "Kioge 2024",
            companykey = "QUEwMDAwMDAyNzky",
            companyid = "MHhhNzA5MDAxNzlhN2JjY2JmMTFkZDUzMjI5YTYzMzgyMw=="
        };
        
        var jsonBody = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(url, content);

        response.EnsureSuccessStatusCode();

        var responseString = await response.Content.ReadAsStringAsync();

        return responseString;
    }
}