using CommunityToolkit.Maui.Alerts;
using Core.Const;
using WASA_Mobile.Service;

namespace WASA_Mobile.Pages;

public partial class ShiftPage : ContentPage
{
    int cash = 0;
    int acquiring = 551;
	public ShiftPage()
	{
		InitializeComponent();
		if(ShiftService.ShiftOpen())
		{
			OpenShiftButton.IsEnabled = false;
            OpenShiftButton.Opacity = 0.5;
            InsertCashButton.IsEnabled = true;
            InsertCashButton.Opacity = 1;
            ExtractCashButton.IsEnabled = true;
            ExtractCashButton.Opacity = 1;
            CloseAcquiringButton.IsEnabled = true;
            CloseAcquiringButton.Opacity = 1;
			CloseShiftButton.IsEnabled = true;
            CloseShiftButton.Opacity = 1;

            DailyBillingLabel.Text = "Выручка за сегодня: " + (cash + acquiring);
            CashBoxAmountLabel.Text = "В кассе:" + cash;
            AcquiringAmountLabel.Text = "Эквайринг: " + acquiring;
		}
	}

    private async void OpenShiftButton_Clicked(object sender, EventArgs e)
    {
        var response = await ShiftService.Open(new() { OpenBy = await SecureStorage.GetAsync(SecureStoragePathConst.Username) });

        if (response != null)
		{

            OpenShiftButton.IsEnabled = false;
            OpenShiftButton.Opacity = 0.5;
            InsertCashButton.IsEnabled = true;
            InsertCashButton.Opacity = 1;
            ExtractCashButton.IsEnabled = true;
            ExtractCashButton.Opacity = 1;
            CloseAcquiringButton.IsEnabled = true;
            CloseAcquiringButton.Opacity = 1;
            CloseShiftButton.IsEnabled = true;
            CloseShiftButton.Opacity = 1;

            DailyBillingLabel.Text = "Выручка за сегодня: " + (response.Total);
            CashBoxAmountLabel.Text = "В кассе:" + response.Cash;
            AcquiringAmountLabel.Text = "Эквайринг: " + response.Acquiring;
        }
    }

    private async void CloseShiftButton_Clicked(object sender, EventArgs e)
    {
		if(AcquiringAmountLabel.Text.Contains("✓"))
        {
            if (await DisplayAlert("Подтверждение закрытия смены", "Вы уверены, что хотите закрыть смену?", "Да", "Нет"))
            {
                if (ShiftService.Close())
                {
                    OpenShiftButton.IsEnabled = true;
                    OpenShiftButton.Opacity = 1;
                    InsertCashButton.IsEnabled = false;
                    InsertCashButton.Opacity = 0.5;
                    ExtractCashButton.IsEnabled = false;
                    ExtractCashButton.Opacity = 0.5;
                    CloseAcquiringButton.IsEnabled = false;
                    CloseAcquiringButton.Opacity = 0.5;
                    CloseShiftButton.IsEnabled = false;
                    CloseShiftButton.Opacity = 0.5;

                    DailyBillingLabel.Text = "Выручка за сегодня: " + (cash + acquiring);
                    CashBoxAmountLabel.Text = "В кассе:" + cash;
                    AcquiringAmountLabel.Text = "Эквайринг: " + acquiring;
                }
            }
        }
        else
        {
            var toast = Toast.Make("Сначала произведите сверку эквайринга");
            await toast.Show();
        }
    }

    private void ScanBarcodeButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new ScanBarcodePage());
    }

    private void WareHouseButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new WareHousePage());
    }

    private void BackToMainButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new MainPage());
    }

    private void InsertCashButton_Clicked(object sender, EventArgs e)
    {
        cash += 100;
        DailyBillingLabel.Text = "Выручка за сегодня: " + (cash + acquiring);
        CashBoxAmountLabel.Text = "В кассе:" + cash;
    }

    private void ExtractCashButton_Clicked(object sender, EventArgs e)
    {
        cash -= 100;
        DailyBillingLabel.Text = "Выручка за сегодня: " + (cash + acquiring);
        CashBoxAmountLabel.Text = "В кассе:" + cash;
    }

    private async void CloseAcquiringButton_Clicked(object sender, EventArgs e)
    {
        if(AcquiringAmountLabel.Text.Contains("✓"))
        {
            if(await DisplayAlert("Подтверждение", "Вы уверены что хотите сделать ещё одну сверку?", "Да", "Нет"))
            {
                AcquiringAmountLabel.Text += "✓";//Remove, now it simply show that`s check correctly work
            }
        }
        else
            AcquiringAmountLabel.Text += "✓";

    }
}