using CarparkTracker.Business.Entities.Carparks;

namespace CarparkTracker.Business.Handlers.Contracts
{
    public interface ICarparkHandler
    {
        CarparksDto GetCarparks();
    }
}