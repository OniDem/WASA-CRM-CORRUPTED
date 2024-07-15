using System.Windows;

namespace WASA_Desktop.AutorizedPages
{
    /// <summary>
    /// Логика взаимодействия для ShiftWindow.xaml
    /// </summary>
    public partial class ShiftWindow : Window
    {
        public ShiftWindow()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            var backWindow = new MainAdminWindow();
            backWindow.Show();
            Close();
        }
    }
}
