using prilogg.Views;
using prilogg.Views.DatailView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace prilogg
{
	public partial class MainPage : MasterDetailPage
	{
      

        public MainPage()
		{
            InitializeComponent();
            Detail = new NavigationPage(new ystroistva())
            {
                BarBackgroundColor = Color.FromHex("40E0D0")
            };
            IsPresented = true;
        }

       

        private void Button1(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new camera())
            {
                BarBackgroundColor = Color.FromHex("40E0D0")
            };
            IsPresented = false;
        }
        private void Button2(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ystroistva())
            {
                BarBackgroundColor = Color.FromHex("40E0D0")
            };
            IsPresented = false;
        }
        private void Button3(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new zapis())
            {
                BarBackgroundColor = Color.FromHex("40E0D0")
            };
            IsPresented = false;
        }
          private void Button4(object sender, EventArgs e)
        {
             Detail = new NavigationPage(new dobavlenie())
            {
               BarBackgroundColor = Color.FromHex("40E0D0")
            };
          IsPresented = false;
         } 
        private void btn_out(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new LoginPage())
            {
                BarBackgroundColor = Color.FromHex("40E0D0")
            };
            IsPresented = false;
        }
    }
}

