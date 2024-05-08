using WASA_Mobile.Service;

namespace WASA_Mobile.Pages
{
    public partial class MainPage : ContentPage
    {
        ApplicationContext context = new();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void First_Clicked(object sender, EventArgs e)
        {
            var user = await context.GetUserInfo();
            await DisplayAlert(Title, user.Id.ToString(), "ok");
        }
    }

}
