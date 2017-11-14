namespace CarparkTracker.Business.Handlers.Contracts
{
    public interface IWebRequestHandler
    {
        TDto GetJsonRequest<TDto>(string url) where TDto : class;
        TDto GetXmlRequest<TDto>(string url) where TDto : class;
    }
}
