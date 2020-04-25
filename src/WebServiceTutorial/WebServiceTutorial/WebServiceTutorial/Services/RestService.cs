using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebServiceTutorial.Models;

namespace WebServiceTutorial.Services
{
    public class RestService
    {
        readonly HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();
        }

        public async Task<UserResponse> GetUserDataAsync(string uri)
        {
            UserResponse userResponse = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    userResponse = JsonConvert.DeserializeObject<UserResponse>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }

            return userResponse;
        }
    }
}
