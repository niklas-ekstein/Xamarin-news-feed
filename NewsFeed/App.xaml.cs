using System;
using NewsFeed.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewsFeed
{
    public partial class App : Application
    {
        public App()
        {
            var toDoNavPage = new Xamarin.Forms.NavigationPage(new NewsFeedPage())
            {
                Title = "News feed posts",
                BarBackgroundColor = Color.FromHex("#2082fa"),
                BarTextColor = Color.White
            };
            //toDoNavPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);

            var completedNavPage = new Xamarin.Forms.NavigationPage(new RemovedPostPage())
            {
                Title = "Removed",
                BarBackgroundColor = Color.FromHex("#2082fa"),
                BarTextColor = Color.White
            };
            //completedNavPage.On<Xamarin.Forms.PlatformConfiguration.iOS>().SetPrefersLargeTitles(true);

            var mainTabbedPage = new TabbedPage
            {
                Children = {
                    toDoNavPage, completedNavPage
                }
            };

            MainPage = mainTabbedPage;


            //InitializeComponent();

            //MainPage = new MainPage();
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
