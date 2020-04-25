using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace WebServiceTutorial.Models
{
    public class UserResponse
    {
        [JsonProperty("_meta")]
        public UserMetaResponse Meta { get; set; }

        [JsonProperty("result")]
        public ObservableCollection<UserData> Result { get; set; }
    }


}
