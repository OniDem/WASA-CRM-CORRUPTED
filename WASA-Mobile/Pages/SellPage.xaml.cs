using CommunityToolkit.Maui.Views;
using Core.Entity;
using System.Collections.ObjectModel;
using WASA_Mobile.Service;

namespace WASA_Mobile.Pages;

public partial class SellPage : ContentPage
{
    private ProductEntity currentProduct = new();
    private ObservableCollection<ProductEntity> receiptList = new();
    public SellPage()
    {
        InitializeComponent();
        BindingContext = receiptList;
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
        currentProduct = await ProductService.SearchProduct(currentProduct.ProductCode);
        BarcodeEntry.Text = currentProduct.ProductCode;
        NameEntry.Text = currentProduct.ProductName;
        CountEntry.Text = "1";
        PriceEntry.Text = currentProduct.Price.ToString();
        
    }

    private void AddProductButton_Clicked(object sender, EventArgs e)
    {
        currentProduct.Count = Convert.ToInt32(CountEntry.Text);
        receiptList.Add(currentProduct);
        receiptListView.ItemsSource = receiptList;
        
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