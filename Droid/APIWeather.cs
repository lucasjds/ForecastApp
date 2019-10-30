using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ForecastApp.Droid
{
    public static class APIWeather
    {
        public static string stringConn = "https://newsapi.org/v2/everything?q=sports&from=2019-04-14&sortBy=publishedAt&apiKey=e2b85c4d87804cb0b6865adf396d9816";
        public static string apiKey = "";


        public static async Task<JsonModel> TestAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(stringConn);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(stringConn).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            string responseBody = await response.Content.ReadAsStringAsync();
            client.Dispose();
            return JsonConvert.DeserializeObject<JsonModel>(responseBody);

        }

    }
}
