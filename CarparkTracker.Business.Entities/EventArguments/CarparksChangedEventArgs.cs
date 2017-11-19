using CarparkTracker.Business.Entities.Carparks;
using System;
using System.Collections.Generic;

namespace CarparkTracker.Business.Entities.EventArguments
{
    public class CarparksChangedEventArgs : EventArgs
    {
        public CarparksChangedEventArgs(IEnumerable<CarparkDto> changedCarparks)
        {
            ChangedCarparks = changedCarparks;
        }

        public IEnumerable<CarparkDto> ChangedCarparks { get; set; }
    }
}