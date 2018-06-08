using prilogg.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using prilogg.Data;
using prilogg.Models;
using System.Threading;
using System.Threading.Tasks;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace prilogg
{
    public partial class App : Application
    {
        static TokenDatabaseController tokenDatabase;
        static UserDatabaseController userDatabase;
        static ystroistvaDatabaseController ystroistvaDatabase;
        static RestService restService;
        private static Label labelScreen;
        private static bool hasIntrnet;
        private static Page currentpage;
        private static Timer timer;
        private static bool noInternetShow;

        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static UserDatabaseController UserDatabase
        {
            get
            {
                if (userDatabase == null)
                {
                    userDatabase = new UserDatabaseController();
                }
                return userDatabase;

            }
        }
        public static TokenDatabaseController TokenDatabase
        {
            get
            {
                if (tokenDatabase == null)
                {
                    tokenDatabase = new TokenDatabaseController();
                }
                return tokenDatabase;

            }
        }
        public static ystroistvaDatabaseController YstroistvaDatabase
        {
            get
            {
                if (ystroistvaDatabase == null)
                {
                    ystroistvaDatabase = new ystroistvaDatabaseController();
                }
                return ystroistvaDatabase;

            }
        }
        public static RestService RestService
        {
            get
            {
                if (restService == null)
                {
                    restService = new RestService();
                }
                return restService;
            }
        }

        //-----------Internet------------------
        public static void StartCheckIfInternet(Label label, Page page)
        {
            labelScreen = label;
            label.Text = Constants.NoInternetText;
            label.IsVisible = false;
            hasIntrnet = true;
            currentpage = page;
            if (timer == null)
            {
                timer = new Timer((e) =>
                {
                    ChekInternetOverTime();
                }, null, 10, (int)TimeSpan.FromSeconds(3).TotalMilliseconds);
            }
        }
        private static void ChekInternetOverTime()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.IsConnected)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (hasIntrnet)
                    {
                        if (!noInternetShow)
                        {
                            hasIntrnet = false;
                            labelScreen.IsVisible = true;
                            await ShowDisplayAlert();
                        }
                    }
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    hasIntrnet = true;
                    labelScreen.IsVisible = false;
                });
            }
        }
        public static async Task<bool> CheckIfInternet()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            return networkConnection.IsConnected;
        }
        public static async Task<bool> CheckIfInternetAlert()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.IsConnected)
            {
                if(!noInternetShow)
                {
                    await ShowDisplayAlert();
                }
                return false;
            }
            return true;
        }
        private static async Task ShowDisplayAlert()
        {
            noInternetShow = false;
            await currentpage.DisplayAlert("Internet", "Device has no internet, please reconnect","Ok");
            noInternetShow = false;
        }
    }
}
