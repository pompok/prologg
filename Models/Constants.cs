using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace prilogg.Models
{
  public  class Constants
    {
        public static bool IsDev = true;

        public static Color BackgroundColor = Color.FromHex("#778899");
        public static Color MainTextColor = Color.White;
        public static int LoginIconHeight = 120;

        //----Login-------
        public static string LoginUrl = "http://test.com/api/Auth/Login";

        public static string NoInternetText = "no internet, please reconnect";
    }
}
