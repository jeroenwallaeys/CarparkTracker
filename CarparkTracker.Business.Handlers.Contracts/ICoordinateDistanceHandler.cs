using CarparkTracker.Business.Entities;

namespace CarparkTracker.Business.Handlers.Contracts
{
    public interface ICoordinateDistanceHandler
    {
        int? GetDistance(Coordinate source, Coordinate destination);
    }
}
