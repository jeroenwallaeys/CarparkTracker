using System;

namespace CarparkTracker.Common.Entities
{
    public class Coordinate
    {
        public Coordinate(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override string ToString()
        {
            var latitudeString = Latitude.ToString().Replace(',', '.');
            var longitudeString = Longitude.ToString().Replace(',', '.');
            return $"{latitudeString},{longitudeString}";
        }
    }
}
