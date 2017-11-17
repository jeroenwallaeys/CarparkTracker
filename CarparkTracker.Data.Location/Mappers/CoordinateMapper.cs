using CarparkTracker.Common.Entities;
using Plugin.Geolocator.Abstractions;

namespace CarparkTracker.Data.Location.Mappers
{
    public static class CoordinateMapper
    {
        public static Coordinate GetCoordinate(this Position position)
        {
            return new Coordinate(position.Latitude, position.Longitude);
        }
    }
}