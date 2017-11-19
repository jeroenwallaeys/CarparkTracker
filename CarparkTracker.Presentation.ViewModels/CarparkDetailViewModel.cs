using CarparkTracker.Presentation.ViewModels.Contracts;
using CarparkTracker.Presentation.Entities;
using CarparkTracker.Presentation.ViewModels.Base;

namespace CarparkTracker.Presentation.ViewModels
{
    public class CarparkDetailViewModel : ViewModelBase, ICarparkDetailViewModel
    {
        public ICarparkDetailViewModel Initialize(object carpark)
        {
            Carpark = carpark as Carpark;
            return this;
        }

        public Carpark Carpark { get; set; }
    }
}
