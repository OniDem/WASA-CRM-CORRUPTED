using Core.Entity;
using System.Windows;
using System.Windows.Controls;
using WASA_Mobile.Service;

namespace WASA_Desktop.AutorizedPages
{
    /// <summary>
    /// Логика взаимодействия для ReceiptViewWindow.xaml
    /// </summary>
    public partial class ReceiptViewWindow : Window
    {
        private readonly List<int> _shiftIds = [1, 2];
        private int _selectedShift;
        public ReceiptViewWindow()
        {
            InitializeComponent();
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
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedShift = Convert.ToInt32(((RadioButton)sender).Content);
        }

        private async void showButton_Click(object sender, RoutedEventArgs e)
        {
            receiptsDG.ItemsSource = await GetReceiptListByShiftID(_selectedShift);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            var backWindow = new MainAdminWindow();
            backWindow.Show();
            Close();
        }

        private async Task<IEnumerable<ReceiptEntity>> GetReceiptListByShiftID(int shiftId)
        {
            ShiftEntity shift = await ShiftService.ShowById(new() { Id = shiftId });
            List<ReceiptEntity> listToReturn = new();
            if(shift.ReceiptsList != null)
            {
                for (int i = 0; i < shift.ReceiptsList.Count; i++)
                {
                    listToReturn.Add(await ReceiptService.GetReceiptById(new() { Id = shift.ReceiptsList[i] }));
                }
            }
            return listToReturn;
        }
    }
}
