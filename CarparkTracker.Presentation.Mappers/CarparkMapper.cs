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
            var availableCapacity = carpark.CarparkStatus.AvailableCapacity < 0 ? 0 : carpark.CarparkStatus.AvailableCapacity;

            var newCarpark =  new Carpark()
            {
                AvailableSpaces = availableCapacity,
                DistanceTo = _distanceHandler.GetDistance(source, new Coordinate(carpark.Latitude, carpark.Longitude)),
                Name = carpark.Name,
                Id = carpark.Id,
                Coordinate = new Coordinate(carpark.Latitude, carpark.Longitude),
                ColorFactor = GetColorFactor(availableCapacity),
                MaximumSpaces = carpark.CarparkStatus.TotalCapacity,
                IsOpen = carpark.CarparkStatus.IsOpen, 
                Address = carpark.Address,
                ContactDetails = carpark.ContactInfo,
                Description = carpark.Description,
            };

            return newCarpark;
        }

        public IEnumerable<Carpark> GetCarparks(CarparkDto[] carparkDtoCollection, Coordinate source)
        {
            return new List<Carpark>(carparkDtoCollection.Select(cp => GetCarpark(cp, source)));
        }

        public Carpark UpdateCarpark(Carpark original, CarparkDto updatedCarpark)
        {
            var availableCapacity = updatedCarpark.CarparkStatus.AvailableCapacity < 0 ? 0 : updatedCarpark.CarparkStatus.AvailableCapacity;

            if ( updatedCarpark.CarparkStatus.AvailableCapacity > 0 )
                original.AvailableSpaces = updatedCarpark.CarparkStatus.AvailableCapacity;
            else
                original.AvailableSpaces = 0;

            original.ColorFactor = GetColorFactor(original.AvailableSpaces);
            original.IsOpen = updatedCarpark.CarparkStatus.IsOpen;

            return original;
        }

        private double GetColorFactor(double availableSpaces)
        {
            var spaces = availableSpaces < 100 ? availableSpaces : 100;
            return 0.27 * ( spaces / 100 );
        }
    }
}