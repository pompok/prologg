using prilogg.Models;
using prilogg.Views.DatailView;
using prilogg.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace prilogg.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
       

        public LoginPage()
        {
            InitializeComponent();
            Init();
        }
        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_Username.TextColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;
            Activity.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;
            App.StartCheckIfInternet(lbl_NoInt, this  );

            Entry_Username.Completed += (s, e) => Entry_Password.Focus();
            Entry_Password.Completed += (s, e) => SignIn(s, e);
        }
        async Task SignIn(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);

            if (user.CheckInformation())
            {
             await   DisplayAlert("Login", "Login Success", "Ok");
                //   var result = await App.RestService.Login(user);
                var result =  new Token();
                if (result != null)
                {
                   // App.UserDatabase.SaveUser(user);
                   // App.TokenDatabase.SaveToken(result);
                  //  await Navigation.PushAsync(new InfoScreen());
                    if (Device.OS == TargetPlatform.Android)
                    {
                        Application.Current.MainPage = new MainPage();
                    }
                    else if(Device.OS == TargetPlatform.iOS)
                            {
                        await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
                    }
                }
            }

            else
            {
          await      DisplayAlert("Login", "Login Not Correct, empty username or password", "Ok");
            }
            }
        }
    }
