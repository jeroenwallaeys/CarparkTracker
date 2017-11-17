namespace CarparkTracker.Data.Contracts.WebRequests
{
    public interface IWebRequests
    {
        TDto GetJsonRequest<TDto>(string url) where TDto : class;
    }
}