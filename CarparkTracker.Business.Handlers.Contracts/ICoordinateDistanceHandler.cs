using CarparkTracker.Common.Entities;

namespace CarparkTracker.Business.Handlers.Contracts
{
    public interface ICoordinateDistanceHandler : IHandler
    {
        int? GetDistance(Coordinate source, Coordinate destination);
    }
}