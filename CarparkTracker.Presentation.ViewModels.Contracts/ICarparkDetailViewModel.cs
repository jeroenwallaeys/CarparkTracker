using CarparkTracker.Presentation.Entities;

namespace CarparkTracker.Presentation.ViewModels.Contracts
{
    public interface ICarparkDetailViewModel : IViewModel
    {
        ICarparkDetailViewModel Initialize(object carpark);
        Carpark Carpark { get; set; }
    }
}