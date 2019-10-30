
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Project;

namespace ForecastApp.Droid
{
    public class PrincipalFragment : Fragment
    {
        private ListView mainList;
        private List<Forecast> myObjectList;
        private DbHelperClass dbHelper;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
            myObjectList = new List<Forecast>();
            dbHelper = new DbHelperClass(this.Activity);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.PrincipalFragment, container, false);
            mainList = view.FindViewById<ListView>(Resource.Id.mainlistview);

            var forecastLista = dbHelper.selectRecords();
            if(forecastLista.Count() > 0)
            {
                foreach (var forecast in forecastLista)
                {
                    myObjectList.Add(new Forecast(forecast.Cidade, "123", "chuva"));
                }
                //creating adapter
                var favAdapter = new MyCustomAdapter(this, myObjectList);
                mainList.SetAdapter(favAdapter);
            }
            
            
            return view;
        }

     
    }
}
