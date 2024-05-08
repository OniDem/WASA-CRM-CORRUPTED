using CommunityToolkit.Maui.Alerts;
using Core.Const;
using WASA_Mobile.Service;

namespace WASA_Mobile.Pages;

public partial class HelloPage : ContentPage
{
    ApplicationContext context;
    ActivityIndicator indicator = new() { Color = Color.FromArgb("#f2f2f2") };
    public HelloPage()
	{
		InitializeComponent();
        context = new();
        indicator.IsRunning = true;
        if (UserService.UserAuthorized())
        {
            Navigation.PushModalAsync(new MainPage());
            Navigation.RemovePage(this);
        }
        indicator.IsRunning = false;
	}

    private void ScanLoginBarcodeButton_Clicked(object sender, EventArgs e)
    {

    }

    private void ScanPasswordBarcodeButton_Clicked(object sender, EventArgs e)
    {

    }

    private async void AuthButton_Clicked(object sender, EventArgs e)
    {
        var toast = Toast.Make("", CommunityToolkit.Maui.Core.ToastDuration.Short);
        if (LoginEntry.Text.Length > 0)
        {
            if (PasswordEntry.Text.Length > 0)
            {
                if (await UserService.AuthUser(new() { Username = LoginEntry.Text, Password = PasswordEntry.Text }))
                {
                    var user = await context.GetUserInfo();
                    await DisplayAlert(Title, user.Id.ToString(), "ok");

                    await Navigation.PushAsync(new MainPage());
                }
            }
            else
                toast = Toast.Make("¬ведите пароль!");
        }
        else
            toast = Toast.Make("¬ведите логин");
        await toast.Show();
    }
}