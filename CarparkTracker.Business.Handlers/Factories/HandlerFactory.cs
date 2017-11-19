using CarparkTracker.Business.Handlers.Contracts;
using CarparkTracker.Common.Containers;

namespace CarparkTracker.Business.Handlers.Factories
{
    public class HandlerFactory : IHandlerFactory
    {
        public THandler Create<THandler>() where THandler : IHandler
        {
            return Resolver.Get<THandler>();
        }
    }
}