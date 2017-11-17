using CarparkTracker.Business.Handlers.Contracts;
using CarparkTracker.Business.Entities;
using CarparkTracker.Business.Handlers.UrlBuilders;
using CarparkTracker.Business.Entities.DistanceMatrices;
using System.Linq;
using CarparkTracker.Common.Entities;

namespace CarparkTracker.Business.Handlers
{
    public class CoordinateDistanceHandler : ICoordinateDistanceHandler
    {
        private readonly IWebRequestHandler _webRequestHandler;

        public CoordinateDistanceHandler(IWebRequestHandler webRequestHandler)
        {
            _webRequestHandler = webRequestHandler;
        }

        public int? GetDistance(Coordinate source, Coordinate destination)
        {
            var distanceMatrix = _webRequestHandler.GetJsonRequest<DistanceMatrixResponseDto>
                (UrlBuilder.GetDistanceUrl(source, destination));
            return distanceMatrix?.Rows?.FirstOrDefault()?.Elements?.FirstOrDefault()?.Distance?.Value;
        }
    }
}
