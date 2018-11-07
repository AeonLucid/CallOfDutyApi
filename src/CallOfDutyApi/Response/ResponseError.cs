using Newtonsoft.Json;

namespace CallOfDutyApi.Response
{
    public class ResponseError
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}