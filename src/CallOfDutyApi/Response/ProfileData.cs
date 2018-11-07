using System.Collections.Generic;
using Newtonsoft.Json;

namespace CallOfDutyApi.Response
{
    public class ProfileData
    {
        [JsonProperty("data")]
        public Profile Data { get; set; }

        [JsonProperty("errors")]
        public List<ResponseError> Errors { get; set; } = new List<ResponseError>();
    }
}