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
using System;
using CarparkTracker.Common.Entities.EventArguments;

namespace CarparkTracker.Presentation.ViewModels
{
    public class CarparksViewModel : ViewModelBase, ICarparsViewModel
    {
        private ObservableCollection<Carpark> _carparks;
        private readonly ICarparkHandler _carparkHandler;
        private readonly IUserLocationHandler _userLocationHandler;
        private readonly ICarparkMapper _carkparkMapper;
        private bool _isLoading;

        public event EventHandler<DisplayAlertEventArgs> DisplayAlertEvent;

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
            try
            {
                IsLoading = true;
                SortCarparks(await GetCarparkCollectionAsync());
                _carparkHandler.CarparksChanged += CarparkHandler_CarparksChanged;
                _userLocationHandler.LocationChanged += CarparkHandler_LocationChanged;
                IsLoading = false;
            }
            catch( Exception )
            {
                DisplayAlert("Probleem bij het laden van de data");
            }

        }

        private void CarparkHandler_LocationChanged(object sender, LocationChangedEventArgs e)
        {
            SortCarparks(Carparks);
        }

        private void CarparkHandler_CarparksChanged(object sender, CarparksChangedEventArgs e)
        {
            try
            {
                foreach ( var updatedCarpark in e.ChangedCarparks )
                {
                    var carparkToUpdate = Carparks.SingleOrDefault(c => c.Id == updatedCarpark.Id);
                    if ( carparkToUpdate == null )
                        continue;
                    _carkparkMapper.UpdateCarpark(carparkToUpdate, updatedCarpark);
                }
            }
            catch
            {
                DisplayAlert("Probleem bij het bijwerken van de parking data");
            }

        }

        private void SortCarparks(IEnumerable<Carpark> carparks)
        {
            Carparks = new ObservableCollection<Carpark>(carparks
                .OrderBy(x => x.DistanceTo == null)
                .ThenBy(x => x.DistanceTo)
                .ThenBy(x => x.Description)
                .ToList());
        }

        private async Task<ObservableCollection<Carpark>> GetCarparkCollectionAsync()
        {
            return await Task.Run(() =>
            {
                Coordinate currentLocation = null;
                try
                {
                    currentLocation = _userLocationHandler.GetCurrentLocation();
                }
                catch ( Exception )
                {
                    DisplayAlert("Kan huidige locatie niet vinden, parkings zullen alfabetisch gerangschikt zijn");
                }

                var carparks = _carparkHandler.GetCarparks();
                return new ObservableCollection<Carpark>(_carkparkMapper.GetCarparks(carparks, currentLocation));
            });
        }

        private void DisplayAlert(string message)
        {
            DisplayAlertEvent?.Invoke(this, new DisplayAlertEventArgs(message));
        }
    }
}