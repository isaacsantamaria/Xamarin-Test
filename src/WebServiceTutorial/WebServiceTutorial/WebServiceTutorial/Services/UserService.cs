using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceTutorial.Models;

namespace WebServiceTutorial.Services
{
    public class UserService
    {
        readonly RestService _restService;

        private readonly ObservableCollection<UserModel> _users;

        public ObservableCollection<UserModel> Users { get; set; }

        public UserService()
        {
            _restService = new RestService();

            if (_users == null)
            {
                _users = new ObservableCollection<UserModel>();
            }
        }

        public async Task<UserResponse> GetListAsync()
        {
            return await _restService.GetUserDataAsync(GenerateRequestUri(Constants.GoRestMapEndpoint));
        }

        public void Save(UserModel model)
        {
            _users.Add(model);
        }

        public void Edit(UserModel model)
        {
            for (int i = 0; i < _users.Count; i++)
            {
                if (_users[i].Id.Equals(model.Id))
                {
                    _users[i] = model;
                }
            }
        }

        public void Delete(int id)
        {
            UserModel model = _users.FirstOrDefault(u => u.Id == id);
            _users.Remove(model);
        }

        private string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?_format=json";
            requestUri += $"&access-token={Constants.GoRestMapAPIKey}";
            return requestUri;
        }
    }
}
