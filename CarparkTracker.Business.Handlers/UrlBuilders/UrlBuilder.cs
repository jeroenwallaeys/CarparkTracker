using CarparkTracker.Business.Entities;
using System.Web;

namespace CarparkTracker.Business.Handlers.UrlBuilders
{
    public static class UrlBuilder
    {
        public static string GetDistanceUrl(Coordinate source, Coordinate destination)
        {
            var url = @"https://maps.googleapis.com/maps/api/distancematrix/json?";

            return url
                .AddParameter("units", "metric")
                .AddParameter("origins", source.ToString())
                .AddParameter("destinations", destination.ToString())
                .AddParameter("key", "AIzaSyAqkdavPO6kCk9p_qAjTm1DwjfeIYW1wR4");
        }

        public static string GetParkingsUrl()
        {
            return @"https://datatank.stad.gent/4/infrastructuur/parkeergarages.xml";
            //return @"https://datatank.stad.gent/4/mobiliteit/bezettingparkingsrealtime";
        }

        private static string AddParameter(this string url, string key, string value)
        {
            return $"{url}&{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(value)}";
        }
    }
}
