using CommunityToolkit.Maui.Alerts;
using Core.Const;
using WASA_Mobile.Service;

namespace WASA_Mobile.Pages;

public partial class HelloPage : ContentPage
{
    ActivityIndicator indicator = new() { Color = Color.FromArgb("#f2f2f2") };
    public HelloPage()
	{
		InitializeComponent();
        indicator.IsRunning = true;
        if (UserService.UserAutorized())
        {
            var stack = Shell.Current.Navigation.NavigationStack.ToArray();
            for (int i = stack.Length - 1; i > 0; i--)
            {
                Shell.Current.Navigation.RemovePage(stack[i]);
            }
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
        
        if (LoginEntry.Text.Length > 0)
        {
            if (PasswordEntry.Text.Length > 0)
            {
                if (await UserService.AuthUser(new() { Username = LoginEntry.Text, Password = PasswordEntry.Text }))
                {
                    await Navigation.PushModalAsync(new MainPage());
                    await DisplayAlert(Title, UserService.GetUserId().ToString(), "ok");
                }
            }
            else
            {
                var toast = Toast.Make("", CommunityToolkit.Maui.Core.ToastDuration.Short);
                toast = Toast.Make("¬ведите пароль!");
                await toast.Show();
            }
        }
        else
        {
            var toast = Toast.Make("", CommunityToolkit.Maui.Core.ToastDuration.Short);
            toast = Toast.Make("¬ведите логин");
            await toast.Show();
        }
        
    }
}