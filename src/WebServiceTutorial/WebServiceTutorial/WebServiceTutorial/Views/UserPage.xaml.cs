using System;
using WebServiceTutorial.Models;
using WebServiceTutorial.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebServiceTutorial.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        readonly UserViewModel _context = new UserViewModel();
        private ToolbarItem CreateAddToolBarItem;

        public UserPage()
        {
            InitializeComponent();
            CreateAddToolBarItem = new ToolbarItem()
            { Text = "+" };
            ToolbarItems.Add(CreateAddToolBarItem);
            CreateAddToolBarItem.Clicked += CreateAddToolBarItem_Clicked;
            BindingContext = _context;
            UsersList.ItemSelected += UsersList_ItemSelected;
            AddUserButton.Clicked += AddUserButton_Clicked;
        }

        private void AddUserButton_Clicked(object sender, EventArgs e)
        {
            UserModel model = new UserModel();
            Navigation.PushAsync(new UserDetailPage(model));
        }

        private void CreateAddToolBarItem_Clicked(object sender, EventArgs e)
        {
            UserModel model = new UserModel();
            Navigation.PushAsync(new UserDetailPage(model));
        }

        private void UsersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                UserModel model = (UserModel)e.SelectedItem;
                Navigation.PushAsync(new UserDetailPage(model));
            }
        }
    }
}