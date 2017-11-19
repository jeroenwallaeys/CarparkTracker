namespace CarparkTracker.Business.Handlers.Contracts
{
    public interface IHandlerFactory
    {
        THandler Create<THandler>() where THandler : IHandler;
    }
}