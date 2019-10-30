
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

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.FavoritosFragment, container, false);

            AssetManager assets = this.Activity.Assets;
            var bytes = default(byte[]);
            using (TextReader reader = new StreamReader(assets.Open("city.list.json")))
            {
                var serializer = new JsonSerializer();
                using (var jsonTextReader = new JsonTextReader(reader))
                {
                    var test = serializer.Deserialize(jsonTextReader);
                    var data = JsonConvert.DeserializeObject<JsonModel>(test.ToString());

                }
            }

            return view;

        }
    }
}
