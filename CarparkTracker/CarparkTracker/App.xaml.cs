using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CarparkTracker
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new CarparkTracker.MainPage();
		}

		protected override void OnStart ()
		{
            InitializeContainer();
		}

        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        private void InitializeContainer()
        {
            var kernel = new StandardKernel();
        }
    }
}
