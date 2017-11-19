using Newtonsoft.Json;

namespace CarparkTracker.Business.Entities.DistanceMatrices
{
    public class ValueObject
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "value")]
        public int Value { get; set; }
    }
}