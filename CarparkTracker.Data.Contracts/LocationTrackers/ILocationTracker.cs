using CarparkTracker.Common.Entities;
using CarparkTracker.Common.Entities.EventArguments;
using System;
using System.Threading.Tasks;

namespace CarparkTracker.Data.Contracts.LocationTrackers
{
    public interface ILocationTracker
    {
        Task<Coordinate> GetCurrentLocationAsync();
        event EventHandler<LocationChangedEventArgs> LocationUpdated;
    }
}