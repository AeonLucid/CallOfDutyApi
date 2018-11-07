using Newtonsoft.Json;

namespace CallOfDutyApi.Response
{
    public class ProfileStat
    {
        [JsonProperty("metadata")]
        public ProfileStatMetadata Metadata { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }

        [JsonProperty("percentile", NullValueHandling = NullValueHandling.Ignore)]
        public double? Percentile { get; set; }

        [JsonProperty("displayValue")]
        public string DisplayValue { get; set; }

        [JsonProperty("displayRank", NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayRank { get; set; }
    }
}