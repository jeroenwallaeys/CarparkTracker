using CarparkTracker.Business.Entities;
using CarparkTracker.Business.Entities.Carparks;
using CarparkTracker.Common.Entities;
using CarparkTracker.Presentation.Entities;
using System.Collections.Generic;

namespace CarparkTracker.Presentation.Mappers.Contracts
{
    public interface ICarparkMapper
    {
        Carpark GetCarpark(CarparkDto carpark, Coordinate source);
        IEnumerable<Carpark> GetCarparks(CarparksDto carParksDto, Coordinate source);
    }
}
