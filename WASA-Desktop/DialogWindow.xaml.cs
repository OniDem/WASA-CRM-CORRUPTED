using System.Windows;

namespace WASA_Desktop
{
    /// <summary>
    /// Логика взаимодействия для DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow(string Message)
        {
            InitializeComponent();
            dialogMessageTextBlock.Text = Message;
            
        }

        public string DialogText
        {
            get { return dialogResponseTextBox.Text; }
            set { dialogResponseTextBox.Text = value; }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
