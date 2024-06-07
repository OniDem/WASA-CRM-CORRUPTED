namespace WASA_Mobile.Pages;

public partial class ReturnPage : ContentPage
{
	public ReturnPage()
	{
		InitializeComponent();
	}
    private void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new MainPage());
    }
}