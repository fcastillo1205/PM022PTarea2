using PM022PTarea2.Services;
using PM022PTarea2.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM022PTarea2
{
    public partial class App : Application
    {
        public static string Firmas = string.Empty;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        public App(string dbLocal)
        {
            InitializeComponent();
            Firmas = dbLocal;
            MainPage = new NavigationPage(new MainPage());
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
