using System;

namespace CarparkTracker.Common.Entities.EventArguments
{
    public class LocationChangedEventArgs : EventArgs
    {
        public LocationChangedEventArgs(Coordinate newLocation)
        {
            NewLocation = newLocation;
        }

        public Coordinate NewLocation { get; set; }
    }
}