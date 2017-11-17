using CarparkTracker.Business.Entities.Carparks;
using CarparkTracker.Business.Handlers.Contracts;
using CarparkTracker.Common.Entities;
using CarparkTracker.Presentation.Entities;
using CarparkTracker.Presentation.Mappers.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CarparkTracker.Presentation.Mappers
{
    public class CarparkMapper : ICarparkMapper
    {
        private readonly ICoordinateDistanceHandler _distanceHandler;

        public CarparkMapper(ICoordinateDistanceHandler distanceHandler)
        {
            _distanceHandler = distanceHandler;
        }

        public Carpark GetCarpark(CarparkDto carpark, Coordinate source)
        {
            return new Carpark()
            {
                AvailableSpaces = carpark.CarparkStatus.AvailableCapacity,
                DistanceTo = _distanceHandler.GetDistance(source, new Coordinate(carpark.Latitude, carpark.Longitude)),
                Name = carpark.Name,
            };
        }

        public IEnumerable<Carpark> GetCarparks(CarparkDto[] carparkDtoCollection, Coordinate source)
        {
            return new List<Carpark>(carparkDtoCollection.Select(cp => GetCarpark(cp, source)));
        }
    }
}