using Newtonsoft.Json;

namespace CallOfDutyApi.Response
{
    public class ProfileStatMetadata
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("categoryKey")]
        public string CategoryKey { get; set; }

        [JsonProperty("categoryName")]
        public string CategoryName { get; set; }

        [JsonProperty("isReversed")]
        public bool IsReversed { get; set; }
    }
}