using System;
using System.Collections.Specialized;
using System.Net;

public class MathService
{
    static readonly HttpClient client = new HttpClient();
    static async Task Main(string[] args)
    {
        try
        {
            HttpResponseMessage response = await client.GetAsync("http://api.mathjs.org/v4/?expr=2%2B5");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Result from the site= {responseBody}");
            double result;
            Double.TryParse(responseBody, out result);
            if (result == 7)
            {

                Console.WriteLine($"Successful execution of the expression 2+5={result}");
            }
            else
            {
                Console.WriteLine("Not successful execution of the expression");
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        string url = "http://api.mathjs.org/v4/?expr=2%2B3*sqrt(4)";
        using (var webClient = new WebClient())            //створюєм об'єкт Веб Клієнт 
        {

            var response = webClient.DownloadString(url);  // виконуєм і отримуєм по адресу відповідь у виді строки
            Console.WriteLine($"Result from the site= {response}");
            double result;
            Double.TryParse(response, out result);
            if (result == 8)
            {

                Console.WriteLine($"Successful execution of the expression 2+3*sqrt(4)={result}");
            }
            else
            {
                Console.WriteLine("Not successful execution of the expression");
            }
        }
    }
}