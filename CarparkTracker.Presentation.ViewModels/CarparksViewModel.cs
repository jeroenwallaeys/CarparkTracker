using CarparkTracker.Business.Handlers.Contracts;
using CarparkTracker.Presentation.Mappers;
using CarparkTracker.Presentation.ViewModels.Base;
using CarparkTracker.Presentation.ViewModels.Contracts;

namespace CarparkTracker.Presentation.ViewModels
{
    public class CarparksViewModel : ViewModelBase, ICarparsViewModel
    {
        private readonly ICarparkHandler _carparkHandler;
        private readonly CarparkMapper _carkparkMapper;

        public CarparksViewModel(ICarparkHandler carparkHandler, CarparkMapper carkparkMapper)
        {
            _carparkHandler = carparkHandler;
            _carkparkMapper = carkparkMapper;
        }
    }
}
