using Newtonsoft.Json;

namespace WebServiceTutorial.Models
{
    public class UserDataLink
    {
        [JsonProperty("avatar")]
        public UserDataLinkAvatar Avatar { get; set; }
    }
}
