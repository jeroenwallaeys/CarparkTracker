using CarparkTracker.Common.Entities;
using CarparkTracker.Common.Entities.EventArguments;
using System;

namespace CarparkTracker.Business.Handlers.Contracts
{
    public interface IUserLocationHandler : IHandler
    {
        event EventHandler<LocationChangedEventArgs> LocationChanged;
        Coordinate GetCurrentLocation();
    }
}