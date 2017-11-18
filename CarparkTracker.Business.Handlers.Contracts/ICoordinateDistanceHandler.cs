using CarparkTracker.Common.Entities;
using System.Threading.Tasks;

namespace CarparkTracker.Business.Handlers.Contracts
{
    public interface ICoordinateDistanceHandler
    {
        int? GetDistance(Coordinate source, Coordinate destination);
    }
}
