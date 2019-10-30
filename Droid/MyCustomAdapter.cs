using System;
using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Content;
using System.Collections;
using System.Collections.Generic;
using Android.Graphics;
using System.Net;
using Android;
using Newtonsoft.Json;

namespace ForecastApp.Droid
{
    public class MyCustomAdapter : BaseAdapter<Data>
    {
        List<Data> forecastList;
        Fragment localContext;

        public MyCustomAdapter(Fragment myContext, List<Data> forecasts) : base()
        {
            localContext = myContext;
            forecastList = forecasts;
        }

        public override Data this[int position]
        {

            get { return forecastList[position]; }
        }

        public override int Count
        {

            get { return forecastList.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            Data myObject = forecastList[position];

            View myView = convertView; // re-use an existing view, if one is

            if (myView == null)
            {
                myView = localContext.LayoutInflater.Inflate(Resource.Layout.PrincipalCustomList, null);

                myView.FindViewById<TextView>(Resource.Id.cidade).Text = myObject.Name;

                myView.FindViewById<TextView>(Resource.Id.clima).Text = myObject.Weather[0].Description;

                myView.FindViewById<TextView>(Resource.Id.temperatura).Text = myObject.Main.Temp;

            }

            return myView;
        }


    }



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

        public Data(string name, string clima, string temperatura)
        {
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