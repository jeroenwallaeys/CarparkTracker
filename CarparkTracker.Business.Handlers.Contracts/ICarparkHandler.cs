using CarparkTracker.Business.Entities.Carparks;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarparkTracker.Business.Handlers.Contracts
{
    public interface ICarparkHandler
    {
        CarparkDto[] GetCarparks();
        void SubscribeOnCarparkChanges(Action<IEnumerable<CarparkDto>> action);
        void Unsubscribe(Action<IEnumerable<CarparkDto>> action);
    }
}