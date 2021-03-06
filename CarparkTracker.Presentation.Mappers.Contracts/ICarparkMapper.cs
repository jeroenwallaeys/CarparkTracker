﻿using CarparkTracker.Business.Entities.Carparks;
using CarparkTracker.Common.Entities;
using CarparkTracker.Presentation.Entities;
using System.Collections.Generic;

namespace CarparkTracker.Presentation.Mappers.Contracts
{
    public interface ICarparkMapper
    {
        Carpark GetCarpark(CarparkDto carpark, Coordinate source);
        IEnumerable<Carpark> GetCarparks(CarparkDto[] carparkDtoCollection, Coordinate source);
        Carpark UpdateCarpark(Carpark original, CarparkDto updatedCarpark);
        IEnumerable<Carpark> UpdateDistances(IEnumerable<Carpark> oldCarparkCollection, Coordinate newLocation);
    }
}