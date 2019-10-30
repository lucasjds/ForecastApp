
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

namespace ForecastApp.Droid
{
    public class PrincipalFragment : Fragment
    {
        private ListView mainList;
        private List<Forecast> myObjectList;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            myObjectList = new List<Forecast>();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.PrincipalFragment, container, false);

            mainList = view.FindViewById<ListView>(Resource.Id.mainlistview);

            AddToList();
            //creating adapter
            var favAdapter = new MyCustomAdapter(this, myObjectList);
            mainList.SetAdapter(favAdapter);

            return view;
        }

        public void AddToList()
        {
            myObjectList.Add(new Forecast("test", "123", "chuva"));
            myObjectList.Add(new Forecast("test", "123", "chuva"));
            myObjectList.Add(new Forecast("test", "123", "chuva"));
            //articleList = dbHelper.selectFavNews(Arguments.GetString("email"));
            /*   foreach (var art in articleList)
               {
                   myObjectList.Add(new UserObejct(art.Title, art.UrlToImage));
               }*/

        }
    }
}
