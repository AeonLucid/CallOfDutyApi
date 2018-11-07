using System.Collections.Generic;
using Newtonsoft.Json;

namespace CallOfDutyApi.Response
{
    public class Profile
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("metadata")]
        public ProfileMetadata Metadata { get; set; }

        [JsonProperty("stats")]
        public List<ProfileStat> Stats { get; set; }
    }
}