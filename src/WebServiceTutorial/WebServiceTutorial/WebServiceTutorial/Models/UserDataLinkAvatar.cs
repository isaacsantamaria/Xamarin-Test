using Newtonsoft.Json;

namespace WebServiceTutorial.Models
{
    public class UserDataLinkAvatar
    {
        [JsonProperty("href")]
        public string Href { get; set; }
    }
}
