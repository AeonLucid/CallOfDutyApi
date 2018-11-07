using System.Collections.Generic;
using Newtonsoft.Json;

namespace CallOfDutyApi.Response
{
    public class ProfileMetadata
    {
        [JsonProperty("statsCategoryOrder")]
        public List<string> StatsCategoryOrder { get; set; }

        [JsonProperty("platformId")]
        public long PlatformId { get; set; }

        [JsonProperty("platformUserHandle")]
        public string PlatformUserHandle { get; set; }

        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [JsonProperty("cacheExpireDate")]
        public string CacheExpireDate { get; set; }
    }
}