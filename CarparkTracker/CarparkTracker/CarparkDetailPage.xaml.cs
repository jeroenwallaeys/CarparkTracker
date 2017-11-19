using CarparkTracker.Presentation.ViewModels.Contracts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;

namespace CarparkTracker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarparkDetailPage : ContentPage
	{
		public CarparkDetailPage (ICarparkDetailViewModel viewModel)
		{
			InitializeComponent ();
            BindingContext = viewModel;

            var mapSpan = MapSpan.FromCenterAndRadius(new Position(viewModel.Carpark.Coordinate.Latitude, viewModel.Carpark.Coordinate.Longitude), Distance.FromKilometers(0.5));

            MyMap.MoveToRegion(mapSpan);
            MyMap.Pins.Add(
                   new Pin
                   {
                       Type = PinType.Place,
                       Position = new Position(viewModel.Carpark.Coordinate.Latitude, viewModel.Carpark.Coordinate.Longitude),
                       Label = viewModel.Carpark.Description,
                       Address = viewModel.Carpark.Address,
                   });
        }
	}
}