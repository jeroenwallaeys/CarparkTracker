using Android.App;
using Android.Content.PM;
using Android.OS;
using CarparkTracker.Common.Containers;
using CarparkTracker.Business.Bootstrapper;
using Plugin.Geolocator;

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

            Test();

            LoadApplication (new CarparkTracker.App ());
		}

        private void InitializeContainers()
        {
            CompositionRoot.Container = new AutofacBuilder().CreateContainer();
        }

        private async void Test()
        {
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                if ( locator.IsGeolocationEnabled )
                {
                    var position = await locator.GetPositionAsync(new System.TimeSpan(0, 0, 5)).Result;
                    position.ToString();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Geolocation is disabled!");
                }
            }
            catch ( System.Exception ex )
            {
                System.Diagnostics.Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
            }
        }
    }
}

