using CarparkTracker.Business.Entities.Carparks;
using CarparkTracker.Business.Handlers.Contracts;
using CarparkTracker.Business.Handlers.UrlBuilders;
using CarparkTracker.Data.Contracts.WebRequests;

namespace CarparkTracker.Business.Handlers
{
    public class CarparkHandler : ICarparkHandler
    {
        private readonly IWebRequests _webRequests;

        public CarparkHandler(IWebRequests webRequests)
        {
            _webRequests = webRequests;
        }

        public CarparkDto[] GetCarparks()
        {
             return _webRequests.GetJsonRequest<CarparkDto[]>(UrlBuilder.GetParkingsUrl());
        }
    }
}