using System.Runtime.CompilerServices;
using System.Windows;
using WASA_CoreLib.Entity;

namespace WASA_Desktop.AutorizedPages
{
    /// <summary>
    /// Логика взаимодействия для MainAdminWindow.xaml
    /// </summary>
    public partial class MainAdminWindow : Window
    {
        private readonly SharedDataEntity sharedDataEntity;
        public MainAdminWindow()
        {
            InitializeComponent();
            Title = $"Главное меню Продавец: 'indev'"; //{sharedDataEntity.UserFIO}
        }

        private void wareHouseButton_Click(object sender, RoutedEventArgs e)
        {
            var wareHouse = new WareHouseAdminWindow();
            wareHouse.Show();
            Close();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            var backWindow = new MainWindow();
            backWindow.Show();
            Close();
        }

        private void receiptButton_Click(object sender, RoutedEventArgs e)
        {
            var receiptWindow = new ReceiptWindow();
            receiptWindow.Show();
            Close();
        }

        private void receiptViewButton_Click(object sender, RoutedEventArgs e)
        {
            var receiptViewWindow = new ReceiptViewWindow();
            receiptViewWindow.Show();
            Close();
        }

        private void currentShiftButton_Click(object sender, RoutedEventArgs e)
        {
            var shiftWindow = new ShiftWindow();
            shiftWindow.Show();
            Close();
        }
    }
}
