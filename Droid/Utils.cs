

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content.Res;
using Newtonsoft.Json;

namespace ForecastApp.Droid
{
    public static class Utils 
    {


        public static void Display(Activity activity, string msg)
        {
            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(activity);
            Android.App.AlertDialog alert = dialog.Create();
            alert.SetTitle("Dialog");
            alert.SetMessage(msg);
            alert.SetButton("OK", (c, ev) =>
            {

                // Ok button click task  
            });
            alert.Show();
        }

        public static List<Data> LerArquivo(Activity activity)
        {
            List<Data> forecasts = new List<Data>();
            AssetManager assets = activity.Assets;
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
                    return forecasts;
                }
            }
        } 

       
    }
}
