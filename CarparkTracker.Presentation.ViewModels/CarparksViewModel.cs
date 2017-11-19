using CarparkTracker.Business.Handlers.Contracts;
using CarparkTracker.Presentation.Entities;
using CarparkTracker.Presentation.Mappers.Contracts;
using CarparkTracker.Presentation.ViewModels.Base;
using CarparkTracker.Presentation.ViewModels.Contracts;
using System.Collections.Generic;
using CarparkTracker.Common.Entities;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq;
using CarparkTracker.Business.Entities.EventArguments;

namespace CarparkTracker.Presentation.ViewModels
{
    public class CarparksViewModel : ViewModelBase, ICarparsViewModel
    {
        private ObservableCollection<Carpark> _carparks;
        private readonly ICarparkHandler _carparkHandler;
        private readonly IUserLocationHandler _userLocationHandler;
        private readonly ICarparkMapper _carkparkMapper;
        private bool _isLoading;

        public CarparksViewModel(IHandlerFactory handlerFactory, ICarparkMapper carkparkMapper)
        {
            _carparkHandler = handlerFactory.Create<ICarparkHandler>();
            _userLocationHandler = handlerFactory.Create<IUserLocationHandler>();
            _carkparkMapper = carkparkMapper;
        }

        public ObservableCollection<Carpark> Carparks
        {
            get { return _carparks; }
            set
            {
                if ( _carparks == value )
                    return;

                _carparks = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                if ( _isLoading == value )
                    return;

                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public async Task OnFormAppearingFirstTime()
        {
            IsLoading = true;
            SortCarparks(await GetCarparkCollectionAsync());
            _carparkHandler.CarparksChanged += CarparkHandler_CarparksChanged;
            _userLocationHandler.LocationChanged += CarparkHandler_LocationChanged;
            IsLoading = false;
        }

        private void CarparkHandler_LocationChanged(object sender, Common.Entities.EventArguments.LocationChangedEventArgs e)
        {
            SortCarparks(Carparks);
        }

        private void CarparkHandler_CarparksChanged(object sender, CarparksChangedEventArgs e)
        {
            foreach ( var updatedCarpark in e.ChangedCarparks )
            {
                var carparkToUpdate = Carparks.SingleOrDefault(c => c.Id == updatedCarpark.Id);
                _carkparkMapper.UpdateCarpark(carparkToUpdate, updatedCarpark);
            }
        }

        private void SortCarparks(IEnumerable<Carpark> carparks)
        {
            Carparks = new ObservableCollection<Carpark>(carparks
                .OrderBy(x => x.DistanceTo)
                .ThenBy(x => x.Description)
                .ToList());
        }

        private async Task<ObservableCollection<Carpark>> GetCarparkCollectionAsync()
        {
            return await Task.Run(() =>
            {
                var carparks = _carparkHandler.GetCarparks();
                return new ObservableCollection<Carpark>(_carkparkMapper.GetCarparks(carparks, new Coordinate(51.123, 50.234)));
            });
        }
    }
}