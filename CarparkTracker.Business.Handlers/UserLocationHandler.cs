using CarparkTracker.Business.Handlers.Contracts;
using System;
using CarparkTracker.Common.Entities;
using CarparkTracker.Common.Entities.EventArguments;
using CarparkTracker.Data.Contracts.LocationTrackers;

namespace CarparkTracker.Business.Handlers
{
    public class UserLocationHandler : IUserLocationHandler
    {
        private readonly ILocationTracker _locationTracker;

        public event EventHandler<LocationChangedEventArgs> LocationChanged;

        public UserLocationHandler(ILocationTracker locationTracker)
        {
            _locationTracker = locationTracker;

            _locationTracker.LocationUpdated += LocationTracker_LocationUpdated;
        }

        private void LocationTracker_LocationUpdated(object sender, LocationChangedEventArgs e)
        {
            LocationChanged?.Invoke(this, e);
        }

        public Coordinate GetCurrentLocation()
        {
            return _locationTracker.GetCurrentLocationAsync();
        }
    }
}