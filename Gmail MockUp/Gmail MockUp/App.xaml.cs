using Gmail_MockUp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gmail_MockUp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ReceivedEmailsPage())
            {
                BarBackgroundColor = Color.FromRgb(204,80,66)
                
            };
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
