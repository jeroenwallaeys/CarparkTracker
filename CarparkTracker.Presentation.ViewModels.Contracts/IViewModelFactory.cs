namespace CarparkTracker.Presentation.ViewModels.Contracts
{
    public interface IViewModelFactory
    {
        TViewModel Create<TViewModel>() where TViewModel : IViewModel;
    }
}
