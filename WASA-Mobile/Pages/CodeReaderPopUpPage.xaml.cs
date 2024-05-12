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
        //For future :)
        //var barcode = SecureStorage.GetAsync(SecureStoragePathConst.Barcode).Result;
        //if (barcode != null )
        //    ScannedCode.Text = "Отсканированный код: " + barcode;
    }


    private async void CodeScanner_OnDetectionFinished(object sender, OnDetectionFinishedEventArg e)
    {
        if(e.BarcodeResults.Length> 0)
        {
            var toast = Toast.Make("");
            CodeScanner.Handler?.DisconnectHandler();
            var result = e?.BarcodeResults?.Any() == true ? e.BarcodeResults[0].DisplayValue : string.Empty;
            await CloseAsync(result);
            //For future :)
            //if (!await UserService.SecureStorageHaveValue(SecureStoragePathConst.Barcode))
            //{
            //    CodeScanner.Handler?.DisconnectHandler();
            //    //await SecureStorage.SetAsync(SecureStoragePathConst.Barcode, barcode.ToString()!);
            //    ScannedCode.Text = "Отсканированный код: " + result;
            //    toast = Toast.Make("Код отсканирован");
            //    await toast.Show();
            //    await CloseAsync(result);
                
            //}
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
            ScannedCode.Text = null;
            CodeScanner.CameraEnabled = true;
        }
    }

    private void ScanCodeAgain_Clicked(object sender, EventArgs e)
    {
        CodeScanner.CameraEnabled = true;
    }
}