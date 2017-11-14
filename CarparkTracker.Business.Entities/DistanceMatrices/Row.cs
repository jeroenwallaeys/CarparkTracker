using Newtonsoft.Json;

namespace CarparkTracker.Business.Entities.DistanceMatrices
{
    public class Row
    {
        [JsonProperty(PropertyName = "elements")]
        public Element[] Elements { get; set; }
    }
}