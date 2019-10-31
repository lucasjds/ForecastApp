
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ForecastApp.Droid
{
    public class PesquisaFragment : Fragment
    {

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.FavoritosFragment, container, false);
            ListView mainList = view.FindViewById<ListView>(Resource.Id.listFavoritos);

            List<Data> forecasts = Utils.LerArquivo(this.Activity);

            ArrayAdapter<String> ad = new ArrayAdapter<String>(this.Activity, Android.Resource.Layout.SimpleListItem1, forecasts.Select(x => x.Name).ToList());
            mainList.SetAdapter(ad);

            mainList.ItemClick += (s, e) => {
                Intent detalheActivity = new Intent(this.Activity, typeof(DetalheActivity));
                detalheActivity.PutExtra("item", forecasts[e.Position].Id);
                StartActivity(detalheActivity);
            };

            return view;

        }
    }
}
