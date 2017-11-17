using CarparkTracker.Business.Entities.Carparks;

namespace CarparkTracker.Business.Handlers.Contracts
{
    public interface ICarparkHandler
    {
        CarparkDto[] GetCarparks();
    }
}