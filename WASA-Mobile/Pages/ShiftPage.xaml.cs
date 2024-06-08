using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using Core.Const;
using Core.Entity;
using WASA_Mobile.Service;

namespace WASA_Mobile.Pages;

public partial class ShiftPage : ContentPage
{
    private ShiftEntity currentShift = Task.Run(async () => await ShiftService.ShowById(new() { Id = Convert.ToInt32(await SecureStorage.GetAsync(SecureStoragePathConst.ShiftID)) })).Result;
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
            AcquiringApproveButton.IsEnabled = true;
            AcquiringApproveButton.Opacity = 1;
			CloseShiftButton.IsEnabled = true;
            CloseShiftButton.Opacity = 1;

            BindingContext = currentShift;
            if(currentShift.AcquiringApproved == true)
            {
                AcquiringAmountLabel.Text += "✓";
            }
        }
        CashBoxAmountLabel.Text = Task.Run(async () => await SecureStorage.GetAsync(SecureStoragePathConst.LastShiftCashBox)).Result;
	}

    private async void OpenShiftButton_Clicked(object sender, EventArgs e)
    {
        var currentShift = await ShiftService.Open(new() { OpenBy = await SecureStorage.GetAsync(SecureStoragePathConst.Username), CashBox = Convert.ToDouble(await SecureStorage.GetAsync(SecureStoragePathConst.LastShiftCashBox)) });

        if (currentShift != null)
		{

            OpenShiftButton.IsEnabled = false;
            OpenShiftButton.Opacity = 0.5;
            InsertCashButton.IsEnabled = true;
            InsertCashButton.Opacity = 1;
            ExtractCashButton.IsEnabled = true;
            ExtractCashButton.Opacity = 1;
            AcquiringApproveButton.IsEnabled = true;
            AcquiringApproveButton.Opacity = 1;
            CloseShiftButton.IsEnabled = true;
            CloseShiftButton.Opacity = 1;
            BindingContext = currentShift;
        }
    }

    private async void CloseShiftButton_Clicked(object sender, EventArgs e)
    {
		if(AcquiringAmountLabel.Text.Contains("✓"))
        {
            if (await DisplayAlert("Подтверждение закрытия смены", "Вы уверены, что хотите закрыть смену?", "Да", "Нет"))
            {
                currentShift = await ShiftService.Close(new() { Id = currentShift.Id, ClosedBy = await SecureStorage.GetAsync(SecureStoragePathConst.Username) });
                if (currentShift.Closed == true)
                {
                    OpenShiftButton.IsEnabled = true;
                    OpenShiftButton.Opacity = 1;
                    InsertCashButton.IsEnabled = false;
                    InsertCashButton.Opacity = 0.5;
                    ExtractCashButton.IsEnabled = false;
                    ExtractCashButton.Opacity = 0.5;
                    AcquiringApproveButton.IsEnabled = false;
                    AcquiringApproveButton.Opacity = 0.5;
                    CloseShiftButton.IsEnabled = false;
                    CloseShiftButton.Opacity = 0.5;
                    await SecureStorage.SetAsync(SecureStoragePathConst.LastShiftCashBox, currentShift.CashBox.ToString());
                    AcquiringAmountLabel.Text = "0";
                    CashBoxAmountLabel.Text = await SecureStorage.GetAsync(SecureStoragePathConst.LastShiftCashBox);

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

    private async void InsertCashButton_Clicked(object sender, EventArgs e)
    {
        var popup = new CashOperationPopUpPage();
        int result = (int)await this.ShowPopupAsync(popup, CancellationToken.None);
        currentShift = await ShiftService.InsertCash(new() { Id = currentShift.Id, CashAmount = result });
        BindingContext = currentShift;
    }

    private async void ExtractCashButton_Clicked(object sender, EventArgs e)
    {
        var popup = new CashOperationPopUpPage();
        int result = (int)await this.ShowPopupAsync(popup, CancellationToken.None);
        currentShift = await ShiftService.ExtractCash(new() { Id = currentShift.Id, CashAmount = result });
        BindingContext = currentShift;
    }

    private async void AcquiringApproveButton_Clicked(object sender, EventArgs e)
    {
        if (AcquiringAmountLabel.Text.Contains('✓'))
        {
            if (await DisplayAlert("Подтверждение", "Вы уверены что хотите сделать ещё одну сверку?", "Да", "Нет"))
            {
                currentShift = await ShiftService.AcquiringApprove(new() { Id = currentShift.Id });
                if (currentShift.AcquiringApproved == true)
                    AcquiringAmountLabel.Text += "✓";
            }
        }
        else
        {
            currentShift = await ShiftService.AcquiringApprove(new() {  Id = currentShift.Id });
            if(currentShift.AcquiringApproved == true)
                AcquiringAmountLabel.Text += "✓";
        }
        BindingContext = currentShift;
    }
}