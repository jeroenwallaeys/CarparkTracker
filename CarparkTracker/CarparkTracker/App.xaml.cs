using CarparkTracker.Common.Configuration;

using Xamarin.Forms;

namespace CarparkTracker
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            MainPage = GetMainPage();
		}

		protected override void OnStart ()
		{
            Settings.CarparkJsonFeed = @"https://datatank.stad.gent/4/mobiliteit/bezettingparkingsrealtime.json";
        }

        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        public static Page GetMainPage()
        {
            return new NavigationPage(new MainPage());
        }
    }
}
