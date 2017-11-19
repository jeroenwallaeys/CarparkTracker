using CarparkTracker.Common.Configuration;
using CarparkTracker.Common.Entities;
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
                .AddParameter("key", "AIzaSyDNTBAmpNwQLTPs7NaCSxnf9ObDY8v5gWk");
        }

        public static string GetParkingsUrl()
        {
            return Settings.CarparkJsonFeed;
            return @"https://datatank.stad.gent/4/mobiliteit/bezettingparkingsrealtime.json";
        }

        private static string AddParameter(this string url, string key, string value)
        {
            return $"{url}&{HttpUtility.UrlEncode(key)}={HttpUtility.UrlEncode(value)}";
        }
    }
}
