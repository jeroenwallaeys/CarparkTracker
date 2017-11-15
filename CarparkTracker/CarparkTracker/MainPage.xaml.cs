using CarparkTracker.Common.Containers;
using CarparkTracker.Presentation.ViewModels.Contracts;
using Xamarin.Forms;

namespace CarparkTracker
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            BindingContext = Resolver.Get<ICarparsViewModel>();
		}

        private void ItemTapped_Carparks(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new CarparkDetailPage(e.Item));
        }
    }
}