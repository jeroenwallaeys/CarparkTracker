using CarparkTracker.Common.Containers;
using CarparkTracker.Presentation.ViewModels.Contracts;

namespace CarparkTracker.Presentation.ViewModels.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        public TViewModel Create<TViewModel>() where TViewModel : IViewModel
        {
            return Resolver.Get<TViewModel>();
        }
    }
}