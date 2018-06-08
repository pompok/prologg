using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prilogg.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace prilogg.Views.DatailView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class zapis : ContentPage
	{
        public List<Zapis> zapiss { get; set; }
        
        public zapis ()
		{
			InitializeComponent ();
            ToolbarItem tb = new ToolbarItem
            {
                Text = "Отправить по почте",
                Order = ToolbarItemOrder.Secondary,
                Priority = 1

            };
          
            ToolbarItems.Add(tb);
            
            zapiss = new List<Zapis>
            {
               
                new Zapis {Name="sclad",  Date = DateTime.Now}

            };
            this.BindingContext = this;
        }
        private async void Ydal1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new zapis());
        }
    }
}