using CommunityToolkit.Maui.Alerts;
using WASA_Mobile.Service;

namespace WASA_Mobile.Pages
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            if(!UserService.UserAutorized())
            {
                Navigation.PushModalAsync(new HelloPage());
            }
            UsernameLabel.Text = "Добро пожаловать " + UserService.GetUserInfoFromSecuteStorage().Username;
        }

        private async void First_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert(Title, UserService.GetUserId().ToString(), "ok");
        }

        private async void LogoutButton_Clicked(object sender, EventArgs e)
        {
            if(await DisplayAlert("Вы уверены?", "Вы уверены что хотите выйти из учётной записи?","Да!", "Нет"))
            {
                UserService.RemoveUserFromSecureStorage();
                var toast = Toast.Make("Вы вышли из учётной записи");
                await toast.Show();
                await Navigation.PushModalAsync(new HelloPage());
            }
        }
    }

}
