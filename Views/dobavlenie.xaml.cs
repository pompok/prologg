using prilogg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prilogg.Data;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace prilogg.Views.DatailView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class dobavlenie : ContentPage
	{
		public dobavlenie ()
		{
			InitializeComponent ();
		}
      // private async void btn_sox(object sender,EventArgs e)
       //{
        //   await Navigation.PushAsync(new ystroistva());
       //}
        private async void btn_sox(object sender, EventArgs e)
        {
          var ystr = (Ystroistva)BindingContext;
         if (!String.IsNullOrEmpty(ystr.Name))
          {
               App.YstroistvaDatabase.SaveYstroistva(ystr);
         }
           await Navigation.PushAsync(new ystroistva());
       }
       public string Name { get; set; }
    }

}