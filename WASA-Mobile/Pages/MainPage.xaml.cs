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
            if(ShiftService.ShiftOpen())
            {
                SellButton.IsEnabled = true;
                SellButton.Opacity = 1;
                ReturnButton.IsEnabled = true;
                ReturnButton.Opacity = 1;
            }
            for(int i = 0; i < Navigation.NavigationStack.Count; i++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[i]);
            }
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

        private void SellButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SellPage());
        }

        private void ReturnButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ReturnPage());
        }

        private void ScanBarcodeButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ScanBarcodePage());
        }

        private void ShiftButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ShiftPage());
        }

        private void WareHouseButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new WareHousePage());
        }

        private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
        {
            if (ShiftService.ShiftOpen())
            {
                SellButton.IsEnabled = true;
                SellButton.Opacity = 1;
                ReturnButton.IsEnabled = true;
                ReturnButton.Opacity = 1;
            }
        }
    }

}
