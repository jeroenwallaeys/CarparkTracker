using CarparkTracker.Common.Containers;
using CarparkTracker.Presentation.ViewModels.Contracts;
using Xamarin.Forms;

namespace CarparkTracker
{
	public partial class MainPage : ContentPage
	{
        bool _initialized;
        private IViewModelFactory _viewModelFactory;

        public MainPage()
		{
            _initialized = false;

            InitializeComponent();
            _viewModelFactory = Resolver.Get<IViewModelFactory>();
            BindingContext = _viewModelFactory.Create<ICarparsViewModel>();
  		}

        private void ItemTapped_Carparks(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new CarparkDetailPage(_viewModelFactory.Create<ICarparkDetailViewModel>().Initialize(e.Item)));
        }

        protected async override void OnAppearing()
        {
            if ( _initialized )
                return;

            var context = (ICarparsViewModel)BindingContext;
            await context.OnFormAppearingFirstTime();
            base.OnAppearing();

            _initialized = true;
        }
    }
}