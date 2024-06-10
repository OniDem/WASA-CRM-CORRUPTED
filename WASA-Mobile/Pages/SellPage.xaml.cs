using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using Core.Const;
using Core.Entity;
using DTO.Product;
using DTO.Receipt;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WASA_Mobile.Service;

namespace WASA_Mobile.Pages;

public partial class SellPage : ContentPage
{
    private ProductEntity currentProduct = new();
    private ReceiptEntity currentReceipt = new();
    private ObservableCollection<ProductEntity> ProductList = new();
    public SellPage()
    {
        InitializeComponent();
        var toast = Toast.Make("Идёт поиск открытых чеков...");
        toast.Show();
        Dispatcher.Dispatch(async () =>
        {
            currentReceipt = await ReceiptService.GetReceiptById(new() { Id = Convert.ToInt32(await SecureStorage.GetAsync(SecureStoragePathConst.ReceiptID)) });
            if (currentReceipt.Id > 0)
            {
                receiptListView.ItemsSource = await FillProductListFromReceipt(currentReceipt);
            }
            else
            {
                toast = Toast.Make("Чеки не найдены");
                await toast.Show();
            }
        });
    }

    private async Task<List<ProductEntity>> FillProductListFromReceipt(ReceiptEntity receipt)
    {
        List<ProductEntity> listToReturn = new();
        foreach (var productCode in receipt.ProductCodes!)
        {
            listToReturn.Add(await ProductService.SearchProduct(new() { ProductCode = productCode }));
        }
        return listToReturn;
    }

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new MainPage());
    }

    private async void ScanBarcodeButton_Clicked(object sender, EventArgs e)
    {

        var popup = new CodeReaderPopUpPage();
        var result = await this.ShowPopupAsync(popup, CancellationToken.None);

        if (result != null)
            if (result is string)
                currentProduct.ProductCode = result as string;
        currentProduct = await ProductService.SearchProduct(new() { ProductCode = currentProduct.ProductCode });
       if(currentProduct.ProductCode.Length == 13)
        {
            BarcodeEntry.Text = currentProduct.ProductCode;
            NameEntry.Text = currentProduct.ProductName;
            CountEntry.Text = "1";
            PriceEntry.Text = currentProduct.Price.ToString();
        }
        else
        {
            var toast = Toast.Make("Продукта с таким штрихкодом не существует");
            toast.Show();
        }
    }

    private async void AddProductButton_Clicked(object sender, EventArgs e)
    {
        var toast = Toast.Make("");
        try
        {
            currentProduct.Count = Convert.ToInt32(CountEntry.Text);
            if (currentReceipt.Id < 0)
            {
                toast = Toast.Make("Идёт создание чека");
                await toast.Show();
                currentReceipt = await ReceiptService.AddReceipt(new()
                {
                    ProductCodes = new() { currentProduct.ProductCode },
                    ProductCounts = new() { Convert.ToDouble(CountEntry.Text) },
                    PayMethod = PayMethodEnum.Cash,
                    Total = Convert.ToDouble(CountEntry.Text) * Convert.ToDouble(PriceEntry.Text),
                    Seller = await SecureStorage.GetAsync(SecureStoragePathConst.Username)
                });
                toast = Toast.Make("Чек создан");
                await toast.Show();
                ProductList.Add(currentProduct);
                Dispatcher.Dispatch(async() => { receiptListView.ItemsSource = await FillProductListFromReceipt(currentReceipt); });

                CashButton.IsEnabled = true;
                AcquiringButton.IsEnabled = true;
                CashButton.Opacity = 1;
                AcquiringButton.Opacity = 1;
            }
            else
            {
                toast = Toast.Make("Добавление продукта");
                await toast.Show();
                AddProductToReceiptRequest request = new() { Id = 0, ProductCodes = new() { }, ProductCounts = new() { } };
                request.Id = currentReceipt.Id;
                request.ProductCodes.Add(currentProduct.ProductCode);
                request.ProductCounts.Add(Convert.ToDouble(CountEntry.Text));

                currentReceipt = await ReceiptService.AddProductToReceipt(request);
                Dispatcher.Dispatch(async() => { receiptListView.ItemsSource = await FillProductListFromReceipt(currentReceipt); });
            }
        }
        catch (Exception)
        {
            toast = Toast.Make("При добавлении произошла ошибка");
            await toast.Show();
        }
        
    }

    private void PayButton_Clicked(object sender, EventArgs e)
    {
        
    }

    private void AcquiringButton_Clicked(object sender, EventArgs e)
    {

    }
}