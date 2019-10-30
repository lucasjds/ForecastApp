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

namespace ForecastApp.Droid
{
    public class MyCustomAdapter : BaseAdapter<Forecast>
    {
        List<Forecast> forecastList;
        Fragment localContext;

        public MyCustomAdapter(Fragment myContext, List<Forecast> forecasts) : base()
        {
            localContext = myContext;
            forecastList = forecasts;
        }

        public override Forecast this[int position]
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

            Forecast myObject = forecastList[position];

            View myView = convertView; // re-use an existing view, if one is

            if (myView == null)
            {
                myView = localContext.LayoutInflater.Inflate(Resource.Layout.PrincipalCustomList, null);

                myView.FindViewById<TextView>(Resource.Id.cidade).Text = myObject.cidade;

                myView.FindViewById<TextView>(Resource.Id.clima).Text = myObject.clima;

                myView.FindViewById<TextView>(Resource.Id.temperatura).Text = myObject.temperatura;



            }

            return myView;
        }


    }



    public class Forecast
    {
        public String cidade;
        public String clima;
        public String temperatura;

        public Forecast(String _cidade, String _clima, String _temperatura)
        {
            cidade = _cidade;
            clima = _clima;
            temperatura = _temperatura;
        }
    }

}