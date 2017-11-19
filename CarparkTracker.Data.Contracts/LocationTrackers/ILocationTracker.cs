using CarparkTracker.Common.Entities;
using CarparkTracker.Common.Entities.EventArguments;
using System;

namespace CarparkTracker.Data.Contracts.LocationTrackers
{
    public interface ILocationTracker
    {
        Coordinate GetCurrentLocationAsync();
        event EventHandler<LocationChangedEventArgs> LocationUpdated;
    }
}