﻿using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ForecastApp.Droid
{
    public static class APIWeather
    {
        public static string stringConn = "https://api.openweathermap.org/data/2.5/weather?appid=2bac87e0cb16557bff7d4ebcbaa89d2f&lang=pt&units=metric&id=";
        
        public static async Task<Data> TestAsync(string id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(stringConn + id);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(stringConn + id).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            string responseBody = await response.Content.ReadAsStringAsync();
            client.Dispose();
            return JsonConvert.DeserializeObject<Data>(responseBody);

        }

    }
}
