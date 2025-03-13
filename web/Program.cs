using System.Net.Http.Json;

namespace web;

class Program
{
    static async Task Main(string[] args)
    {
        var url = "https://catfact.ninja";
        Uri uri = new(url);

        Console.WriteLine(uri.Host);
        Console.WriteLine(uri.Port);
        
        using HttpClient client = new()
        {
            BaseAddress = uri
        }; 
        
        var response = await client.GetAsync("fact");
        
        response.EnsureSuccessStatusCode();
        
        Console.WriteLine(response.Content.ReadAsStringAsync().Result);

        var cosesdegat = await client.GetFromJsonAsync<Gat>("fact");

        if (cosesdegat != null) Console.WriteLine(cosesdegat.fact);
    }
}

public class Gat
{
    public string fact { get; set; }
    public int length { get; set; }
}













