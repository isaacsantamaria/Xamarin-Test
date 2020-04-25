using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceTutorial.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WebServiceTutorial.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailPage : ContentPage
    {
        public UserDetailPage(UserModel model)
        {
            InitializeComponent();
            BindingContext = model;
            SaveButton.IsVisible = model.Id.Equals(0);
            EditButton.IsVisible = !SaveButton.IsVisible;
        }
    }
}