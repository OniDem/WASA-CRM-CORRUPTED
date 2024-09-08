using Core.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WASA_CoreLib.Entity;
using WASA_Desktop.Service;

namespace WASA_Desktop.AutorizedPages
{
    /// <summary>
    /// Логика взаимодействия для ReceiptViewWindow.xaml
    /// </summary>
    public partial class ReceiptViewWindow : Window
    {
        
        private int _selectedShift;
        public ReceiptViewWindow()
        {
            InitializeComponent();
            Dispatcher.Invoke(async () =>
            {
                List<int> _shiftIds = await ShiftService.ShowAllIds();
                _shiftIds.Reverse();
                for (int i = 0; i < _shiftIds!.Count(); i++)
                {
                    RadioButton radioButton = new()
                    {
                        GroupName = "Shifts",
                        Content = _shiftIds![i],
                        Margin = new(2)
                    };
                    radioButton.Click += RadioButton_Click;
                    shiftChoiceStackPanel.Children.Add(radioButton);
                }
            });
            
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedShift = Convert.ToInt32(((RadioButton)sender).Content);
        }

        private async void showButton_Click(object sender, RoutedEventArgs e)
        {
            if(_selectedShift > 0)
            {
                DisplayStatus("warning", 1000, $"Поиск чеков за смену №{_selectedShift}");
                Title = $"Чеки за смену №{_selectedShift}";
                receiptsDG.ItemsSource = await GetReceiptListByShiftID(_selectedShift);
                DisplayStatus("good", 1000, $"Чеки успешно получены");
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            var backWindow = new MainAdminWindow();
            backWindow.Show();
            Close();
        }

        private async Task<IEnumerable<ReceiptShowEntity>> GetReceiptListByShiftID(int shiftId)
        {
            ShiftEntity shift = await ShiftService.ShowById(new() { Id = shiftId });
            List<ReceiptShowEntity> listToReturn = [];
            if(shift.ReceiptsList != null)
            {
                for (int i = 0; i < shift.ReceiptsList.Count; i++)
                {
                    ReceiptEntity receipt = await ReceiptService.GetReceiptById(new() { Id = shift.ReceiptsList[i] });
                    ReceiptShowEntity showEntity = new();
                    showEntity.Id = receipt.Id;
                    showEntity.LoyaltyCardID = receipt.LoyaltyCardID;
                    showEntity.LoyaltyBonusAdded = receipt.LoyaltyBonusAdded;
                    showEntity.ProductCodes = receipt.ProductCodes![0];
                    showEntity.ProductCategories = receipt.ProductCategories![0];
                    showEntity.ProductNames = receipt.ProductNames![0];
                    showEntity.ProductPrices = receipt.ProductPrices![0].ToString();
                    showEntity.ProductCount = receipt.ProductCount![0].ToString();
                    switch(receipt.PayMethod)
                    {
                        case Core.Const.PayMethodEnum.Cash:
                            showEntity.PayMethod = "Наличные";
                            break;
                        case Core.Const.PayMethodEnum.Acquiring:
                            showEntity.PayMethod = "Эквайринг";
                            break;
                    }
                    showEntity.Total = receipt.Total;
                    showEntity.Canceled = receipt.Canceled;
                    showEntity.CancelReason = receipt.CancelReason.ToString();
                    showEntity.Closed = receipt.Closed;
                    showEntity.Seller = receipt.Seller;
                    showEntity.CreationDate = receipt.CreationDate;
                    showEntity.CancelDate = receipt.CancelDate;
                    showEntity.ClosedDate = receipt.ClosedDate;
                    showEntity.PaymentDate = receipt.PaymentDate;
                    for (int j = 1; j < receipt.ProductCodes.Count; j++)
                    {
                        showEntity.ProductCodes += ", " + receipt.ProductCodes![j];
                        showEntity.ProductCategories += ", " + receipt.ProductCategories![j];
                        showEntity.ProductNames += ", " + receipt.ProductNames![j];
                        showEntity.ProductPrices += ", " + receipt.ProductPrices![j].ToString(); ;
                        showEntity.ProductCount += ", " + receipt.ProductCount![j].ToString(); ;
                    }
                    listToReturn.Add(showEntity);
                }
            }
            return listToReturn;
        }

        /// <summary>
        /// Method to display some text on statusLabel
        /// </summary>
        /// <param name="type">Status type(available error, warning, good)</param>
        /// <param name="time">Timer time</param>
        /// <param name="statusText">Text to display</param>
        private async void DisplayStatus(string type, int time, string statusText)
        {
            switch (type)
            {
                case "error":
                    statusLabel.Foreground = Brushes.Red;
                    break;
                case "warning":
                    statusLabel.Foreground = Brushes.Gold;
                    break;
                case "good":
                    statusLabel.Foreground = Brushes.Green;
                    break;
            }
            statusLabel.Content = statusText;
            statusLabel.Visibility = Visibility.Visible;
            await Task.Delay(time);
            statusLabel.Visibility = Visibility.Hidden;
        }
    }
}
