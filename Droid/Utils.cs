

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Android.App;

namespace Project
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

       
    }
}
