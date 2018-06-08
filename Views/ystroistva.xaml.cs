using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prilogg.Data;
using prilogg.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace prilogg.Views.DatailView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ystroistva : ContentPage

	{
       // public string[] Ystr { get; set; }
       public List<Ystroistva> Ystroistvas { get; set; }

        public ystroistva ()
           

		{            
			InitializeComponent ();
            Ystroistvas = new List<Ystroistva>
            {
                
                
                new Ystroistva {Name="sklad", ip="37.18.26.109", port="34567" }

            };
            this.BindingContext = this;
        }
       
        //dobavlenie
        private async void Yst(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new dobavlenie());
        }
        private async void Ydal(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new dobavlenie());
        }

      //ydalenie
          private  void Ydal(object sender, EventArgs e)
         {
            var ystr = (Ystroistva)BindingContext;
          App.YstroistvaDatabase.Deleteystroistva(ystr.Id);
         this.Navigation.PopAsync();

        }
    }
    
}