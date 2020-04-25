using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WebServiceTutorial.Models;
using WebServiceTutorial.Services;
using Xamarin.Forms;

namespace WebServiceTutorial.ViewModels
{
    public class UserViewModel : UserModel
    {
        readonly UserService _userService = new UserService();
        UserModel _model;

        private ObservableCollection<UserModel> _users;

        public ObservableCollection<UserModel> Users
        {
            get { return _users; }
            set { _users = value; }
        }

        public UserViewModel()
        {
            if (_users == null)
            {
                _users = new ObservableCollection<UserModel>();
            }
            _ = GetListUsers();
            SaveCommand = new Command(async () => await Save(), () => IsBusy);
            EditCommand = new Command(async () => await Edit(), () => IsBusy);
            DeleteCommand = new Command(async () => await Delete(), () => IsBusy);
            ClearCommand = new Command(Clear, () => IsBusy);
            GetListCommand = new Command(async () => await GetListUsers(), () => IsBusy);
        }

        public Command SaveCommand { get; set; }
        public Command EditCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Command ClearCommand { get; set; }
        public Command GetListCommand { get; set; }


        private async Task GetListUsers()
        {
            IsBusy = true;
            UserResponse userResponse = await _userService.GetListAsync();

            if (userResponse != null)
            {
                if (userResponse.Meta.Success.Equals("true"))
                {
                    foreach (var userData in userResponse.Result)
                    {
                        _users.Add(new UserModel()
                        {
                            FirstName = userData.FirstName,
                            LastName = userData.LastName,
                            Phone = userData.Phone,
                            Id = userData.Id,
                            Avatar = userData.Links.Avatar.Href
                        });
                    }
                }
            }

            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Save()
        {
            int idUser = _users.Count + 1;
            IsBusy = true;
            _model = new UserModel()
            {
                FirstName = FirstName,
                LastName = LastName,
                Phone = Phone,
                Id = idUser
            };

            _userService.Save(_model);
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Edit()
        {
            IsBusy = true;
            _model = new UserModel()
            {
                FirstName = FirstName,
                LastName = LastName,
                Phone = Phone,
                Id = Id
            };

            _userService.Edit(_model);
            await Task.Delay(2000);
            IsBusy = false;
        }

        private async Task Delete()
        {
            IsBusy = true;
            _userService.Delete(Id);
            await Task.Delay(2000);
            IsBusy = false;
        }

        private void Clear()
        {
            FirstName = string.Empty;
            LastName = string.Empty;
            Phone = string.Empty;
            Id = 0;
        }
    }
}
