using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Xamarin.Forms.Maps;

namespace CarparkTracker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarparkDetailPage : ContentPage
	{
		public CarparkDetailPage (object dataContext)
		{
			InitializeComponent ();
            BindingContext = dataContext;

            //MyMap.Pins.Add(
            //       new Pin
            //       {
            //           Type = PinType.Place,
            //           Position = new Position(37.79752, -122.40183),
            //           Label = "Xamarin San Francisco Office",
            //           Address = "394 Pacific Ave, San Francisco CA",

            //       });
        }
	}
}