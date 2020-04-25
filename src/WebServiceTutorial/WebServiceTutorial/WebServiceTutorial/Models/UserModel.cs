using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WebServiceTutorial.Models
{
    public class UserModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isBusy = false;

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        private int _id;
        public int Id {
            get { return _id; }
            set 
            { 
                _id = value;
                OnPropertyChanged(); 
            } 
        }

        private string _firstName;
        public string FirstName { 
            get { return _firstName; } 
            set 
            { 
                _firstName = value; 
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            } 
        }

        private string _lastName;
        public string LastName 
        { 
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            } 
        }

        private string _fullName;

        public string FullName
        {
            get { return $"Nombre: {FirstName} {LastName}"; }
            set 
            { 
                _fullName = value;
                OnPropertyChanged();
            }
        }

        private string _phone;
        public string Phone 
        { 
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged();
            } 
        }

        private string _fullPhone;
        public string FullPhone
        {
            get { return $"Teléfono: {Phone}"; }
            set
            {
                _fullPhone = value;
                OnPropertyChanged();
            }
        }

        public string Avatar { get; set; }
    }
}
