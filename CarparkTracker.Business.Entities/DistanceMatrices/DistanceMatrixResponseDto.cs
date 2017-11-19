using Newtonsoft.Json;

namespace CarparkTracker.Business.Entities.DistanceMatrices
{
    public class DistanceMatrixResponseDto
    {
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "origin_addresses")]
        public string[] OriginAddresses { get; set; }

        [JsonProperty(PropertyName = "destination_addresses")]
        public string[] DestinationAddresses { get; set; }

        [JsonProperty(PropertyName = "rows")]
        public Row[] Rows { get; set; }
    }
}