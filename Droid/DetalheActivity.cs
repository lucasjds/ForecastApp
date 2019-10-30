
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ForecastApp.Droid
{
    [Activity(Label = "DetalheActivity")]
    public class DetalheActivity : Activity
    {
        public static string stringConn = "https://newsapi.org/v2/everything?q=sports&from=2019-04-14&sortBy=publishedAt&apiKey=e2b85c4d87804cb0b6865adf396d9816";
        public static string apiKey = "";


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var cidade = Intent.GetStringExtra("item");
        }

        
        
    }
}
