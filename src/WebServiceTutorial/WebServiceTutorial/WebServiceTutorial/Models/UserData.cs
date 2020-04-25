using Newtonsoft.Json;

namespace WebServiceTutorial.Models
{
    public class UserData
    {

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("_links")]
        public UserDataLink Links { get; set; }
    }
}
