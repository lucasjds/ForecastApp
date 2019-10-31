
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
using Project;

namespace ForecastApp.Droid
{
    [Activity(Label = "DetalheActivity")]
    public class DetalheActivity : Activity
    {
        private DbHelperClass dbHelper ;
        private Data data;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Detalhe);
            dbHelper = new DbHelperClass(this);
            var id = Intent.GetStringExtra("item");
            PreencheTela(id);

            Button voltar = FindViewById<Button>(Resource.Id.voltar);
            voltar.Click += delegate {
                this.Finish();
            };
            
            Button add = FindViewById<Button>(Resource.Id.add);
            add.Click += delegate {
                if (dbHelper.insertRecord(data))
                {
                    Utils.Display(this, "Adicionado com sucesso");
                }

            };

            Button remove = FindViewById<Button>(Resource.Id.remove);
            remove.Click += delegate {
                if (dbHelper.deleteRecord(data.Id))
                {
                    Utils.Display(this, "Removido com sucesso");
                }
            };
        }


        private async void PreencheTela(string id)
        {
            data = await APIWeather.TestAsync(id);
            TextView cidade = FindViewById<TextView>(Resource.Id.cidade);
            cidade.Text = data.Name;
            TextView temperatura = FindViewById<TextView>(Resource.Id.temperatura);
            temperatura.Text = data.Main.Temp;
            TextView tempMax = FindViewById<TextView>(Resource.Id.tempMax);
            tempMax.Text = data.Main.TempMax;
            TextView tempMin = FindViewById<TextView>(Resource.Id.tempMin);
            tempMin.Text = data.Main.TempMin;
            TextView desc = FindViewById<TextView>(Resource.Id.desc);
            desc.Text = data.Weather[0].Description;

        }
    }
}
