using Newtonsoft.Json;

namespace CarparkTracker.Business.Entities.Carparks
{
    public class CarparkDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "contactInfo")]
        public string ContactInfo { get; set; }

        [JsonProperty(PropertyName = "parkingStatus")]
        public CarparkStatusDto CarparkStatus { get; set; }
    }
}