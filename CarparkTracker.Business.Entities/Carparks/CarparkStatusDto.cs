using Newtonsoft.Json;

namespace CarparkTracker.Business.Entities.Carparks
{
    public class CarparkStatusDto
    {

        [JsonProperty(PropertyName = "availableCapacity")]
        public int AvailableCapacity { get; set; }

        [JsonProperty(PropertyName = "totalCapacity")]
        public int TotalCapacity { get; set; }

        [JsonProperty(PropertyName = "open")]
        public bool IsOpen { get; set; }

        [JsonProperty(PropertyName = "lastModifiedDate")]
        public string LastModifiedDate { get; set; }
    }

}