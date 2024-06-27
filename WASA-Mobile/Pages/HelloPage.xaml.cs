using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
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

    private async void ScanLoginBarcodeButton_Clicked(object sender, EventArgs e)
    {
        var popup = new CodeReaderPopUpPage();
        var result = await this.ShowPopupAsync(popup, CancellationToken.None);

        if (result != null)
            if (result is string)
                LoginEntry.Text = result as string;
    }

    private async void ScanPasswordBarcodeButton_Clicked(object sender, EventArgs e)
    {
        var popup = new CodeReaderPopUpPage();
        var result = await this.ShowPopupAsync(popup, CancellationToken.None);
        var toast = Toast.Make("");
        if (result != null)
        {
            if (result is string)
                PasswordEntry.Text = result as string;
            if (LoginEntry.Text.Length > 0)
            {
                if (PasswordEntry.Text!.Length > 0)
                {
                    var response = await UserService.AuthUser(new() { Username = LoginEntry.Text, Password = PasswordEntry.Text });
                    if (response == "Успешно")
                    {
                        toast = Toast.Make("Вы успешно авторизованны");
                        await toast.Show();
                        await Navigation.PushModalAsync(new MainPage());
                    }
                    else if (response == "Пустой ответ")
                    {
                        toast = Toast.Make("Такого пользователя не существует");
                        await toast.Show();
                    }
                    else
                    {
                        toast = Toast.Make("Произошла ошибка");
                        await toast.Show();
                    }
                }
                else
                {
                    toast = Toast.Make("Введите пароль!");
                    await toast.Show();
                }
            }
            else
            {
                toast = Toast.Make("Введите логин");
                await toast.Show();
            }
        }
        
    }

    private async void AuthButton_Clicked(object sender, EventArgs e)
    {
        var toast = Toast.Make("");
        if (LoginEntry.Text != null)
        {
            if(PasswordEntry.Text != null)
            {
                if (LoginEntry.Text.Length > 0)
                {
                    if (PasswordEntry.Text.Length > 0)
                    {
                        var response = await UserService.AuthUser(new() { Username = LoginEntry.Text, Password = PasswordEntry.Text });
                        if (response == "Успешно")
                        {
                            toast = Toast.Make("Вы успешно авторизованны");
                            await toast.Show();
                            await Navigation.PushModalAsync(new MainPage());
                        }
                        else if (response == "Пустой ответ")
                        {
                            toast = Toast.Make("Такого пользователя не существует");
                            await toast.Show();
                        }
                        else
                        {
                            toast = Toast.Make("Произошла ошибка");
                            await toast.Show();
                        }    
                    }
                    else
                    {
                        toast = Toast.Make("Введите пароль!");
                        await toast.Show();
                    }
                }
            }
            else
            {
                toast = Toast.Make("Введите пароль");
                await toast.Show();
            }
        }
        else
        {
            toast = Toast.Make("Введите логин");
            await toast.Show();
        }
        
    }
}