using CarparkTracker.Business.Handlers.Contracts;
using CarparkTracker.Presentation.Mappers.Contracts;
using CarparkTracker.Presentation.ViewModels.Base;
using CarparkTracker.Presentation.ViewModels.Contracts;

namespace CarparkTracker.Presentation.ViewModels
{
    public class CarparksViewModel : ViewModelBase, ICarparsViewModel
    {
        private readonly ICarparkHandler _carparkHandler;
        private readonly ICarparkMapper _carkparkMapper;

        public CarparksViewModel(ICarparkHandler carparkHandler, ICarparkMapper carkparkMapper)
        {
            _carparkHandler = carparkHandler;
            _carkparkMapper = carkparkMapper;
        }
    }
}
