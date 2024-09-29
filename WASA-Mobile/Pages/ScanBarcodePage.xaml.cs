using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using Core.Const;
using WASA_Mobile.Service;

namespace WASA_Mobile.Pages;

public partial class ScanBarcodePage : ContentPage
{
	public ScanBarcodePage()
	{
		InitializeComponent();

	}

    private void ShiftButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new ShiftPage());
    }

    private void WareHouseButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new WareHousePage());
    }

    private void BackToMainButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new MainPage());
    }

    private async void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        try
        {
            var popup = new CodeReaderPopUpPage();
            var result = await this.ShowPopupAsync(popup, CancellationToken.None);

            if (result != null)
            {
                if (result is string)
                {
                    var toast = Toast.Make("Идёт поиск товара", CommunityToolkit.Maui.Core.ToastDuration.Long);
                    await toast.Show();
                    var product = await ProductService.SearchProduct(new() { ProductCode = result as string });
                    if (product != null)
                    {
                        toast = Toast.Make("Товар найден", CommunityToolkit.Maui.Core.ToastDuration.Short);
                        await toast.Show();
                        BarcodeLabel.Text = "Штрихкод: " + product.ProductCode;
                        CategoryLabel.Text = "Категория: " + product.Category;
                        CategoryLabel.Text = "Категория: " + product.Category;
                        CategoryLabel.Text = "Категория: " + product.Category;
                        NameLabel.Text = "Наименование: " + product.ProductName;
                        PriceLabel.Text = "Цена: " + product.Price;
                        CountLabel.Text = "Остаток: " + product.Count;
                    }
                    else
                    {
                        toast = Toast.Make($"Товара с таким штрихкодом не существует", CommunityToolkit.Maui.Core.ToastDuration.Long);
                        await toast.Show();
                    }

                }
            }
            else
            {
                var toast = Toast.Make("При сканировании штрихкода произошла ошибка", CommunityToolkit.Maui.Core.ToastDuration.Long);
                await toast.Show();
            }
        }
        catch (Exception)
        {
        }
    }
    private async void ScanBarcodeButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            var popup = new CodeReaderPopUpPage();
            var result = await this.ShowPopupAsync(popup, CancellationToken.None);

            if (result != null)
            {
                if (result is string)
                {
                    CommunityToolkit.Maui.Core.IToast toast = Toast.Make("Идёт поиск товара", CommunityToolkit.Maui.Core.ToastDuration.Long);
                    await toast.Show();
                    var product = await ProductService.SearchProduct(new() { ProductCode = result as string });
                    if (product != null)
                    {
                        toast = Toast.Make("Товар найден", CommunityToolkit.Maui.Core.ToastDuration.Short);
                        await toast.Show();
                        BarcodeLabel.Text = "Штрихкод: " + product.ProductCode;
                        CategoryLabel.Text = "Категория: " + product.Category;
                        NameLabel.Text = "Наименование: " + product.ProductName;
                        PriceLabel.Text = "Цена: " + product.Price;
                        CountLabel.Text = "Остаток: " + product.Count;
                    }
                    else
                    {
                        toast = Toast.Make("Товара с таким штрихкодом не существует", CommunityToolkit.Maui.Core.ToastDuration.Long);
                        await toast.Show();
                    }

                }
            }
            else
            {
                var toast = Toast.Make("При сканировании штрихкода произошла ошибка", CommunityToolkit.Maui.Core.ToastDuration.Long);
                await toast.Show();
            }
        }
        catch (Exception)
        {
        }
    }

    private async void sendCodeButton_Clicked(object sender, EventArgs e)
    {
        if (BarcodeLabel.Text != null)
        {
            var barcode = BarcodeLabel.Text.Remove(0, 10);
            if (barcode.Length == 13)
            {
                var data = await SharedDataService.Update(new() { UserId = Convert.ToInt32(await SecureStorage.GetAsync(SecureStoragePathConst.Id)), Barcode = barcode });
                if (data != null)
                {
                    if (data.Barcode != null)
                    {
                        var toast = Toast.Make("Штрихкод отправлен");
                        await toast.Show();
                    }
                }
                else
                {
                    var toast = Toast.Make("При отправке произошла ошибка");
                    await toast.Show();
                }
            }
        }
    }

    private async void scanButton_Clicked(object sender, EventArgs e)
    {
        try
        {
            var popup = new CodeReaderPopUpPage();
            var result = await this.ShowPopupAsync(popup, CancellationToken.None);

            if (result != null)
            {
                if (result is string)
                {
                    var toast = Toast.Make("Идёт поиск товара", CommunityToolkit.Maui.Core.ToastDuration.Long);
                    await toast.Show();
                    var product = await ProductService.SearchProduct(new() { ProductCode = result as string });
                    if (product != null)
                    {
                        toast = Toast.Make("Товар найден", CommunityToolkit.Maui.Core.ToastDuration.Short);
                        await toast.Show();
                        BarcodeLabel.Text = "Штрихкод: " + product.ProductCode;
                        CategoryLabel.Text = "Категория: " + product.Category;
                        NameLabel.Text = "Наименование: " + product.ProductName;
                        PriceLabel.Text = "Цена: " + product.Price;
                        CountLabel.Text = "Остаток: " + product.Count;
                    }
                    else
                    {
                        toast = Toast.Make("Товара с таким штрихкодом не существует", CommunityToolkit.Maui.Core.ToastDuration.Long);
                        await toast.Show();
                    }

                }
            }
            else
            {
                var toast = Toast.Make("При сканировании штрихкода произошла ошибка", CommunityToolkit.Maui.Core.ToastDuration.Long);
                await toast.Show();
            }
        }
        catch (Exception)
        {
        }
    }
}