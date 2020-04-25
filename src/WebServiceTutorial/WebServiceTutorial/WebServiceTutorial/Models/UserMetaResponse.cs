using Newtonsoft.Json;

namespace WebServiceTutorial.Models
{
    public class UserMetaResponse
    {
        [JsonProperty("success")]
        public string Success { get; set; }
        
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
