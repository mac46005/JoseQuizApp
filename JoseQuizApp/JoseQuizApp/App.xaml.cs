using JoseQuizApp.Views;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JoseQuizApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory
                .GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            MainPage = new NavigationPage(Resolver.Resolve<MainView>());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
