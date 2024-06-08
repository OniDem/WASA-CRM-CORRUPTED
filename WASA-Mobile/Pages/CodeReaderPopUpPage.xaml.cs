using BarcodeScanning;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using Core.Const;
using WASA_Mobile.Service;

namespace WASA_Mobile.Pages;

public partial class CodeReaderPopUpPage : Popup
{
    public CodeReaderPopUpPage()
    {
		InitializeComponent();
        CodeScanner.CameraEnabled = true;
        Task.Run(async () => { await Permissions.RequestAsync<Permissions.Camera>(); });
    }


    private async void CodeScanner_OnDetectionFinished(object sender, OnDetectionFinishedEventArg e)
    {
        if(e.BarcodeResults.Length> 0)
        {
            var toast = Toast.Make("");
            CodeScanner.Handler?.DisconnectHandler();
            string result = (e?.BarcodeResults?.Any()) != true ? string.Empty : e.BarcodeResults[0].DisplayValue;
            await CloseAsync(result);
        }
    }

    private async void DeleteScannedCode_Clicked(object sender, EventArgs e)
    {
        var barcode = await SecureStorage.GetAsync(SecureStoragePathConst.Barcode);
        while (barcode != null)
        {
            SecureStorage.Remove(SecureStoragePathConst.Barcode);
            barcode = await SecureStorage.GetAsync(SecureStoragePathConst.Barcode);
        }
        if (!await UserService.SecureStorageHaveValue(SecureStoragePathConst.Barcode))
        {
            CodeScanner.CameraEnabled = true;
        }
    }

    private void ScanCodeAgain_Clicked(object sender, EventArgs e)
    {
        CodeScanner.CameraEnabled = true;
    }
}