
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
        private List<Data> forecasts;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            forecasts = new List<Data>();
            // Create yfoour fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.FavoritosFragment, container, false);
            ListView mainList = view.FindViewById<ListView>(Resource.Id.listFavoritos);

            AssetManager assets = this.Activity.Assets;
            var bytes = default(byte[]);
            
            using (TextReader reader = new StreamReader(assets.Open("city.list.json")))
            {
                var serializer = new JsonSerializer();
                using (var jsonTextReader = new JsonTextReader(reader))
                {
                    var test = serializer.Deserialize(jsonTextReader);
                    var datas = JsonConvert.DeserializeObject<JsonModel>(test.ToString());
                    foreach (var data in datas.Data)
                    {
                        forecasts.Add(data);
                    }
                }
            }
            ArrayAdapter<String> ad = new ArrayAdapter<String>(this.Activity, Android.Resource.Layout.SimpleListItem1, forecasts.Select(x => x.Name).ToList());
            mainList.SetAdapter(ad);

            mainList.ItemClick += (s, e) => {
                Intent detalheActivity = new Intent(this.Activity, typeof(DetalheActivity));
                var t = forecasts[e.Position];
                detalheActivity.PutExtra("item", t.Id);
                StartActivity(detalheActivity);
            };

            return view;

        }
    }
}
