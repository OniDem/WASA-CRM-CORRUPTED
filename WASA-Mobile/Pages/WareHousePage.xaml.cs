using CommunityToolkit.Maui.Alerts;
using Core.Entity;
using WASA_Mobile.Service;

namespace WASA_Mobile.Pages;

public partial class WareHousePage : ContentPage
{
    public List<ProductEntity> Products { get; set; }
	public WareHousePage()
	{
		InitializeComponent();
        wareHouseListView.BeginRefresh();
        var toast = Toast.Make("Началась загрузка товаров. Ожидайте", CommunityToolkit.Maui.Core.ToastDuration.Long);
        toast.Show();
    }

    private void ShiftButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new ShiftPage());
    }

    private void ScanBarcodeButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new ScanBarcodePage());
    }

    private void BackToMainButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new MainPage());
    }

    private async void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        Products = await ProductService.GetAllProducts();
        //wareHouseListView.ItemsSource = Products;
        productCount.Text = "Количество: " + Products.Count;
        BindingContext = this;
        wareHouseListView.EndRefresh();
    }

    private async void wareHouseListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var product = e.SelectedItem as ProductEntity;
        await DisplayAlert("Информация о товаре", "Штрихкод: " + product.ProductCode + "\n Категория: " + ConvertService.CategoryConvertToString(product.Category) + "\n Наименование: " + product.ProductName + "\n Цена: " + product.Price + "\n Количество: " + product.Count, "Ок");
    }
}