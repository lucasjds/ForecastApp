using Android.App;
using Android.Widget;
using Android.OS;

namespace ForecastApp.Droid
{
    [Activity(Label = "ForecastApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            SetContentView(Resource.Layout.Main);

            PrincipalFragment aPrincipal = new PrincipalFragment();
            PesquisaFragment aPesquisa = new PesquisaFragment();
            
            AddTab("Principal",  aPrincipal);
            AddTab("Pesquisa", aPesquisa);

        }

        void AddTab(string tabText, Fragment fragment)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);

            // must set event handler for replacing tabs tab
            tab.TabSelected += delegate (object sender, ActionBar.TabEventArgs e) {
                e.FragmentTransaction.Replace(Resource.Id.fragmentContainer, fragment);
            };

            this.ActionBar.AddTab(tab);
        }

    }
}

