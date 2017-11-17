using CarparkTracker.Business.Handlers.Contracts;
using CarparkTracker.Business.Handlers.UrlBuilders;
using CarparkTracker.Business.Entities.DistanceMatrices;
using System.Linq;
using CarparkTracker.Common.Entities;
using CarparkTracker.Data.Contracts.WebRequests;

namespace CarparkTracker.Business.Handlers
{
    public class CoordinateDistanceHandler : ICoordinateDistanceHandler
    {
        private readonly IWebRequests _webRequests;

        public CoordinateDistanceHandler(IWebRequests webRequests)
        {
            _webRequests = webRequests;
        }

        public int? GetDistance(Coordinate source, Coordinate destination)
        {
            var distanceMatrix = _webRequests.GetJsonRequest<DistanceMatrixResponseDto>
                (UrlBuilder.GetDistanceUrl(source, destination));
            return distanceMatrix?.Rows?.FirstOrDefault()?.Elements?.FirstOrDefault()?.Distance?.Value;
        }
    }
}
