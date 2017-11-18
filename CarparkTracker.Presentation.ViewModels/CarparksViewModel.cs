using CarparkTracker.Business.Handlers.Contracts;
using CarparkTracker.Presentation.Entities;
using CarparkTracker.Presentation.Mappers.Contracts;
using CarparkTracker.Presentation.ViewModels.Base;
using CarparkTracker.Presentation.ViewModels.Contracts;
using System.Collections.Generic;
using CarparkTracker.Common.Entities;
using CarparkTracker.Business.Entities.Carparks;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq;

namespace CarparkTracker.Presentation.ViewModels
{
    public class CarparksViewModel : ViewModelBase, ICarparsViewModel
    {
        private ObservableCollection<Carpark> _carparks;
        private Coordinate _coordinates;
        private readonly ICarparkHandler _carparkHandler;
        private readonly ICarparkMapper _carkparkMapper;
        private bool _isLoading;

        public CarparksViewModel(ICarparkHandler carparkHandler, ICarparkMapper carkparkMapper)
        {
            _carparkHandler = carparkHandler;
            _carkparkMapper = carkparkMapper;
        }

        private void UpdateCarparks(IEnumerable<CarparkDto> updatedCarparks)
        {
            foreach ( var updatedCarpark in updatedCarparks )
            {
                var carparkToUpdate = Carparks.SingleOrDefault(c => c.Id == updatedCarpark.Id);
                _carkparkMapper.UpdateCarpark(carparkToUpdate, updatedCarpark);
            }
        }

        public async Task OnFormAppearingFirstTime()
        {
            IsLoading = true;
            Carparks = await GetCarparkCollectionAsync();
            _carparkHandler.SubscribeOnCarparkChanges(UpdateCarparks);
            IsLoading = false;
        }

        private async Task<ObservableCollection<Carpark>> GetCarparkCollectionAsync()
        {
            return await Task.Run(() =>
            {
                var carparks = _carparkHandler.GetCarparks();
                return new ObservableCollection<Carpark>(_carkparkMapper.GetCarparks(carparks, new Coordinate(51, 51)));
            });
        }

        public ObservableCollection<Carpark> Carparks
        {
            get { return _carparks; }
            set {
                if ( _carparks == value )
                    return;

                _carparks = value;
                OnPropertyChanged();
            }
        }

        public Coordinate Coordinates
        {
            get { return _coordinates; }
            set
            {
                if ( _coordinates == value )
                    return;

                _coordinates = value;
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
    }
}