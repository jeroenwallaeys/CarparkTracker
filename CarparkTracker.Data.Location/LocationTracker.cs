using Plugin.Geolocator;
using CarparkTracker.Common.Entities;
using CarparkTracker.Data.Location.Mappers;
using System.Threading.Tasks;
using CarparkTracker.Data.Contracts.LocationTrackers;
using CarparkTracker.Common.Entities.EventArguments;
using System;

namespace CarparkTracker.Data.Location
{
    public class LocationTracker : ILocationTracker
    {
        public LocationTracker()
        {
            CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
        }

        public event EventHandler<LocationChangedEventArgs> LocationUpdated;

        private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            LocationUpdated?.Invoke(this, new LocationChangedEventArgs(e.Position.GetCoordinate()));
        }

        public Task<Coordinate> GetCurrentLocationAsync()
        {
            return Task.Run(async () =>
            {
                var result = await CrossGeolocator.Current.GetPositionAsync(new TimeSpan(0, 0, 0, 10));
                return result.GetCoordinate();

            });
        }
    }
}