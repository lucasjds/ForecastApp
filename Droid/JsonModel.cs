using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ForecastApp.Droid
{
    public class JsonModel
    {
        public JsonModel() { }

        [JsonProperty(PropertyName = "data")]
        public List<Data> Data;

    }

    public class Data
    {
        public Data()
        {
            Weather = new List<Weather>();
            Main = new Main();
        }

        public Data(string id, string name, string clima, string temperatura)
        {
            Id = id;
            Name = name;
            Main = new Main(temperatura);
            Weather = new List<Weather>();
            Weather.Add(new Weather(clima));
        }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "weather")]
        public List<Weather> Weather { get; set; }
        [JsonProperty(PropertyName = "main")]
        public Main Main { get; set; }

    }

    public class Weather
    {
        public Weather(string desc)
        {
            Description = desc;
        }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }

    public class Main
    {
        public Main() { }

        public Main(string temp)
        {
            Temp = temp;
        }
        [JsonProperty(PropertyName = "temp")]
        public string Temp { get; set; }
        [JsonProperty(PropertyName = "temp_min")]
        public string TempMin { get; set; }
        [JsonProperty(PropertyName = "temp_max")]
        public string TempMax { get; set; }
    }
}
