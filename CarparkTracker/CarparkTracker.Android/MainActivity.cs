﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Ninject;
using CarparkTracker.Common.Containers;
using CarparkTracker.Business.Bootstrapper;

namespace CarparkTracker.Droid
{
	[Activity (Label = "CarparkTracker", Icon = "@drawable/icon", Theme="@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
            InitializeContainers();

			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar; 

			base.OnCreate (bundle);

			global::Xamarin.Forms.Forms.Init (this, bundle);
			LoadApplication (new CarparkTracker.App ());
		}

        private void InitializeContainers()
        {
            var kernel = new StandardKernel(new Module());
            CompositionRoot.Kernel = kernel;
        }
	}
}

