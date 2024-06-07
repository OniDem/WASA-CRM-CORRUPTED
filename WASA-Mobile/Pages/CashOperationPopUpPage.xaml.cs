using CommunityToolkit.Maui.Views;

namespace WASA_Mobile.Pages;

public partial class CashOperationPopUpPage : Popup
{
	public CashOperationPopUpPage()
	{
		InitializeComponent();

	}

    private async void ApproveButton_Clicked(object sender, EventArgs e)
    {
        await CloseAsync(Convert.ToInt32(CashAmountEntry.Text));
    }
}