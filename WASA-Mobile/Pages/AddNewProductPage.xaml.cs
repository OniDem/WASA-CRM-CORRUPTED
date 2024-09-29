using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using Core.Const;
using Core.Entity;
using System.Collections.ObjectModel;
using WASA_Mobile.Service;

namespace WASA_Mobile.Pages;

public partial class AddNewProductPage : ContentPage
{
    private CategoryShowEntity? _currentCategory;
    public AddNewProductPage()
	{
		InitializeComponent();
        Task.Run(async () =>
        {
            CategoryCarouselView.ItemsSource = await CategoryService.GetAll();
        });
	}
    private void BackToMainButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private async void ScanProductCodeButton_Clicked(object sender, EventArgs e)
    {
        var popup = new CodeReaderPopUpPage();
        var result = await this.ShowPopupAsync(popup, CancellationToken.None);

        if (result != null)
            if (result is string)
                ProductCodeEntry.Text = result as string;
    }

    private void CategoryCarouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
    {
        _currentCategory = e.CurrentItem as CategoryShowEntity;
    }

    private async void AddProductButton_Clicked(object sender, EventArgs e)
    {
        if(ProductCodeEntry.Text != null)
        {
            if(NameEntry.Text != null)
            {
                if(PriceEntry.Text != null)
                {
                    if(AmountEntry.Text != null)
                    {
                        if(ProductCodeEntry.Text.Length > 0 && NameEntry.Text.Length > 0 && PriceEntry.Text.Length > 0 && AmountEntry.Text.Length > 0)
                        {
                            var result = await ProductService.AddProduct(new()
                            {
                                ProductCode = ProductCodeEntry.Text,
                                Category = _currentCategory!.CategoryName,
                                ProductName = NameEntry.Text,
                                Price = Convert.ToDouble(PriceEntry.Text),
                                Count = Convert.ToDouble(AmountEntry.Text)
                            });
                            var toast = Toast.Make($"������� � ����������: {result.ProductCode} ��������");
                            await toast.Show();
                            ProductCodeEntry.Text = "";
                            NameEntry.Text = "";
                            PriceEntry.Text = "";
                            AmountEntry.Text = "";
                        }
                    }
                }
            }
        }
    }

    private async void ProductCodeEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if(ProductCodeEntry.Text.Length == 13)
        {
            var product = await ProductService.SearchProduct(new() { ProductCode = ProductCodeEntry.Text });
            if (product.ProductCode.Length > 0)
            {
                var toast = Toast.Make($"������� ��� ����������");
                await toast.Show();
                AddProductButton.IsEnabled = false;
                AddProductButton.Opacity = 0.5;
            }
            else
            {
                AddProductButton.IsEnabled = true;
                AddProductButton.Opacity = 1;
            }
        }
    }

    private async void sendCodeButton_Clicked(object sender, EventArgs e)
    {
        if(ProductCodeEntry.Text != null)
        {
            if(ProductCodeEntry.Text.Length == 13)
            {
                var data = await SharedDataService.Update(new() { UserId = Convert.ToInt32(await SecureStorage.GetAsync(SecureStoragePathConst.Id)), Barcode =  ProductCodeEntry.Text });
                if(data != null)
                {
                    if (data.Barcode != null)
                    {
                        var toast = Toast.Make("�������� ���������");
                        await toast.Show();
                    }
                }
                else
                {
                    var toast = Toast.Make("��� �������� ��������� ������");
                    await toast.Show();
                }
            }
        }
    }
}