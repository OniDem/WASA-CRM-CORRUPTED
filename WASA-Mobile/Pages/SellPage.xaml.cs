using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using Core.Const;
using Core.Entity;
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
        currentReceipt = Task.Run(async () => await ReceiptService.GetReceiptById(new() { Id = Convert.ToInt32(await SecureStorage.GetAsync(SecureStoragePathConst.ReceiptID)) }) ).Result;
        if(currentReceipt != null)
        {
            Dispatcher.Dispatch(() => { BindingContext = FillProductListFromReceipt(currentReceipt); });
        }
    }

    private async IAsyncEnumerable<ProductEntity> FillProductListFromReceipt(ReceiptEntity receipt)
    {
        foreach (var productCode in receipt.ProductCodes!)
        {
            yield return await ProductService.SearchProduct(new() {  ProductCode =  productCode });
        }
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

    private void AddProductButton_Clicked(object sender, EventArgs e)
    {
        currentProduct.Count = Convert.ToInt32(CountEntry.Text);
        
        ProductList.Add(currentProduct);
        Dispatcher.Dispatch(() => { receiptListView.ItemsSource = ProductList; });  

        CashButton.IsEnabled = true;
        AcquiringButton.IsEnabled = true;
        CashButton.Opacity = 1;
        AcquiringButton.Opacity = 1;
    }

    private void PayButton_Clicked(object sender, EventArgs e)
    {
        
    }

    private void AcquiringButton_Clicked(object sender, EventArgs e)
    {

    }
}