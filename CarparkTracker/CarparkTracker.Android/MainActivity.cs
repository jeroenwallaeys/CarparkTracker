﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using CarparkTracker.Common.Containers;
using CarparkTracker.Business.Bootstrapper;

namespace CarparkTracker.Droid
{
	[Activity (Label = "CarparkTracker", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        
        protected override void OnCreate (Bundle bundle)
		{
            InitializeContainers();

			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar; 

			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);

            Xamarin.FormsMaps.Init(this, bundle);

            LoadApplication (new CarparkTracker.App ());
		}

        private void InitializeContainers()
        {
            CompositionRoot.Container = new AutofacBuilder().CreateContainer();
        }
    }
}