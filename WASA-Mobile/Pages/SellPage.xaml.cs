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
        Task.Run(async () => { await Permissions.RequestAsync<Permissions.Camera>(); });
        var toast = Toast.Make("Идёт поиск открытых чеков...");
        toast.Show();
        Dispatcher.Dispatch(async () =>
        {
            currentReceipt = await ReceiptService.GetReceiptById(new() { Id = Convert.ToInt32(await SecureStorage.GetAsync(SecureStoragePathConst.ReceiptID)) });
            if (currentReceipt.Id > 0 && currentReceipt.ProductCodes!.Count > 0)
            {
                receiptListView.ItemsSource = await FillProductListFromReceipt(currentReceipt);
                TotalLabel.Text = currentReceipt.Total.ToString();
                CashButton.IsEnabled = true;
                AcquiringButton.IsEnabled = true;
                CashButton.Opacity = 1;
                AcquiringButton.Opacity = 1;
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
        if (receipt != null)
        {
            if(receipt.Id > 0)
            {
                for (int i = 0; i < receipt.ProductCodes!.Count; i++)
                {
                    var product = await ProductService.SearchProduct(new() { ProductCode = receipt.ProductCodes[i] });
                    product.Count = receipt.ProductCount![i];
                    product.Price = receipt.ProductPrices![i];
                    listToReturn.Add(product);
                }            }
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
            if(BarcodeEntry.Text.Length > 0)
            {
                if(NameEntry.Text.Length > 0)
                {
                    if(CountEntry.Text.Length > 0)
                    {
                        if(PriceEntry.Text.Length > 0)
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
                                Dispatcher.Dispatch(async () => { receiptListView.ItemsSource = await FillProductListFromReceipt(currentReceipt); });

                                TotalLabel.Text = currentReceipt.Total.ToString();
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
                                Dispatcher.Dispatch(async () => { receiptListView.ItemsSource = await FillProductListFromReceipt(currentReceipt); });

                                TotalLabel.Text = currentReceipt.Total.ToString();
                                CashButton.IsEnabled = true;
                                AcquiringButton.IsEnabled = true;
                                CashButton.Opacity = 1;
                                AcquiringButton.Opacity = 1;
                            }
                        }
                    }
                }
            }
        }
        catch (Exception)
        {
            toast = Toast.Make("При добавлении произошла ошибка");
            await toast.Show();
        }
        
    }

    private async void PayButton_Clicked(object sender, EventArgs e)
    {
        var toast = Toast.Make("Производится синхронизация оплаты");
        await toast.Show();
        var receipt = await ReceiptService.Payment(new() { Id = currentReceipt.Id, PayMethod = PayMethodEnum.Cash, PaymentDate = DateTime.UtcNow, Total = currentReceipt.Total });
        if (receipt.Id > 0)
        {
            currentReceipt = receipt;
            receipt = await ReceiptService.Close(new() { Id = currentReceipt.Id });
            if (receipt.Id > 0)
            {

                CashButton.IsEnabled = false;
                AcquiringButton.IsEnabled = false;
                CashButton.Opacity = 1;
                AcquiringButton.Opacity = 1;
                toast = Toast.Make("Чек успешно закрыт");
                await toast.Show();
                currentReceipt = new()
                {
                    Id = -1,
                    ProductCodes = new() { },
                    ProductCount = new() { },
                    PayMethod = PayMethodEnum.Cash,
                    Total = 0,
                    Seller = "",
                };
                currentProduct = new();
                SecureStorage.Remove(SecureStoragePathConst.ReceiptID);
                receiptListView.ItemsSource = await FillProductListFromReceipt(currentReceipt);
                await ShiftService.AddReceiptToShift(new() { ReceiptId = receipt.Id, Cash = receipt.Total, Acquiring = 0, Total = receipt.Total, Id = Convert.ToInt32(SecureStorage.GetAsync(SecureStoragePathConst.ShiftID)) });
            }

        }
    }

    private async void AcquiringButton_Clicked(object sender, EventArgs e)
    {
        var toast = Toast.Make("Производится синхронизация оплаты");
        await toast.Show();
        var receipt = await ReceiptService.Payment(new() { Id = currentReceipt.Id, PayMethod = PayMethodEnum.Acquiring, PaymentDate = DateTime.UtcNow, Total = currentReceipt.Total });
        if (receipt.Id > 0)
        {
            currentReceipt = receipt;
            receipt = await ReceiptService.Close(new() { Id = currentReceipt.Id });
            if (receipt.Id > 0)
            {
                CashButton.IsEnabled = false;
                AcquiringButton.IsEnabled = false;
                CashButton.Opacity = 1;
                AcquiringButton.Opacity = 1;
                toast = Toast.Make("Чек успешно закрыт");
                await toast.Show();
                currentReceipt = new()
                {
                    ProductCodes = new() { },
                    ProductCount = new() { },
                    PayMethod = PayMethodEnum.Cash,
                    Total = 0,
                    Seller = "",
                };
                currentProduct = new();
                SecureStorage.Remove(SecureStoragePathConst.ReceiptID);
                receiptListView.ItemsSource = await FillProductListFromReceipt(currentReceipt);
                await ShiftService.AddReceiptToShift(new() { ReceiptId = receipt.Id, Cash = 0, Acquiring = receipt.Total, Total = receipt.Total, Id = Convert.ToInt32(SecureStorage.GetAsync(SecureStoragePathConst.ShiftID)) });
            }
        }
    }
}