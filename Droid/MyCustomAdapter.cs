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



    
}