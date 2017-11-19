using Plugin.Geolocator;
using CarparkTracker.Common.Entities;
using CarparkTracker.Data.Location.Mappers;
using CarparkTracker.Data.Contracts.LocationTrackers;
using CarparkTracker.Common.Entities.EventArguments;
using System;
using Plugin.Geolocator.Abstractions;

namespace CarparkTracker.Data.Location
{
    public class LocationTracker : ILocationTracker
    {
        private IGeolocator _geolocator;

        public LocationTracker()
        {
            _geolocator = CrossGeolocator.Current;
            _geolocator.PositionChanged += Current_PositionChanged;
        }

        public event EventHandler<LocationChangedEventArgs> LocationUpdated;

        private void Current_PositionChanged(object sender, PositionEventArgs e)
        {
            LocationUpdated?.Invoke(this, new LocationChangedEventArgs(e.Position.GetCoordinate()));
        }

        public Coordinate GetCurrentLocationAsync()
        {
            var result = _geolocator.GetPositionAsync().Result;
            return result.GetCoordinate();
        }
    }
}