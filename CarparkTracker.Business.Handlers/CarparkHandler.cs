using CarparkTracker.Business.Entities.Carparks;
using CarparkTracker.Business.Handlers.Contracts;
using CarparkTracker.Business.Handlers.UrlBuilders;

namespace CarparkTracker.Business.Handlers
{
    public class CarparkHandler : ICarparkHandler
    {
        private readonly IWebRequestHandler _webRequestHandler;

        public CarparkHandler(IWebRequestHandler webRequestHandler)
        {
            _webRequestHandler = webRequestHandler;
        }

        public CarparksDto GetCarparks()
        {
            return _webRequestHandler.GetXmlRequest<CarparksDto>(UrlBuilder.GetParkingsUrl());
        }
    }
}
