using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarparkTracker
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarparkDetailPage : ContentPage
	{
		public CarparkDetailPage (object dataContext)
		{
			InitializeComponent ();
            BindingContext = dataContext;
		}
	}
}