using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace prilogg.Views.DatailView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class camera : ContentPage
	{
		public camera ()
		{
			InitializeComponent ();

            ToolbarItem tb = new ToolbarItem
            {
                Text = "Сохранить видео в приложении",
                Order  = ToolbarItemOrder.Secondary,
                Priority = 1
                
            };
            ToolbarItem tb1 = new ToolbarItem
            {
                Text = "Сохранить видео в памяти устройства",
                Order = ToolbarItemOrder.Secondary,
                Priority = 2

            };
            ToolbarItems.Add(tb);
            ToolbarItems.Add(tb1);

        }
	}
}