using CarparkTracker.Business.Entities.Carparks;
using CarparkTracker.Business.Entities.EventArguments;
using CarparkTracker.Common.Entities.EventArguments;
using System;
using System.Collections.Generic;

namespace CarparkTracker.Business.Handlers.Contracts
{
    public interface ICarparkHandler
    {
        CarparkDto[] GetCarparks();
        event EventHandler<CarparksChangedEventArgs> CarparksChanged;
        event EventHandler<LocationChangedEventArgs> LocationChanged; 
    }
}