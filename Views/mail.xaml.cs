using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace prilogg.почта
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class mail : ContentPage
	{


        Entry emailMessenger;
        Button sendButton;
        public mail ()
        {
            emailMessenger = new Entry { Placeholder = "Введите email" };
            sendButton = new Button { Text = "Send" };
            sendButton.Clicked += (o, e) =>
            {
                var emailMessenger = CrossMessaging.Current.EmailMessenger;
                if (emailMessenger.CanSendEmail)
                {
                    emailMessenger.SendEmail("адрес получателя", "тема письма", "текст письма");
                }
            };

            Content = new StackLayout
            {
                Children = { emailMessenger, sendButton }
            };
        }
    }
}