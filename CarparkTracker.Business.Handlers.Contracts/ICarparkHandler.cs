using CarparkTracker.Business.Entities.Carparks;
using CarparkTracker.Business.Entities.EventArguments;
using System;

namespace CarparkTracker.Business.Handlers.Contracts
{
    public interface ICarparkHandler : IHandler
    {
        CarparkDto[] GetCarparks();
        event EventHandler<CarparksChangedEventArgs> CarparksChanged;
    }
}