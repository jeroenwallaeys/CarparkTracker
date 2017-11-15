using CarparkTracker.Business.Handlers.Contracts;
using CarparkTracker.Presentation.Entities;
using CarparkTracker.Presentation.Mappers.Contracts;
using CarparkTracker.Presentation.ViewModels.Base;
using CarparkTracker.Presentation.ViewModels.Contracts;
using System.Collections.Generic;
using System;

namespace CarparkTracker.Presentation.ViewModels
{
    public class CarparksViewModel : ViewModelBase, ICarparsViewModel
    {
        private List<Carpark> _carparks;

        private readonly ICarparkHandler _carparkHandler;
        private readonly ICarparkMapper _carkparkMapper;

        public CarparksViewModel(ICarparkHandler carparkHandler, ICarparkMapper carkparkMapper)
        {
            _carparkHandler = carparkHandler;
            _carkparkMapper = carkparkMapper;

            Initialize();
        }

        private void Initialize()
        {
            var carparks = _carparkHandler.GetCarparks();
            Carparks = new List<Carpark>(_carkparkMapper.GetCarparks(_carparkHandler.GetCarparks(), new Business.Entities.Coordinate(51, 51)));
        }

        public List<Carpark> Carparks
        {
            get { return _carparks; }
            set {
                if ( _carparks == value )
                    return;

                _carparks = value;
                OnPropertyChanged();
            }
        }
    }
}
