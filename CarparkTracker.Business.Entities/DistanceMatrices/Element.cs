using Newtonsoft.Json;

namespace CarparkTracker.Business.Entities.DistanceMatrices
{
    public class Element
    {
        [JsonProperty(PropertyName = "distance")]
        public ValueObject Distance { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public ValueObject Duration { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}