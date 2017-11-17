using CarparkTracker.Business.Entities;
using CarparkTracker.Common.Entities;

namespace CarparkTracker.Business.Handlers.Contracts
{
    public interface ICoordinateDistanceHandler
    {
        int? GetDistance(Coordinate source, Coordinate destination);
    }
}
