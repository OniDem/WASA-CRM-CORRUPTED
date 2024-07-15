using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WASA_Desktop.AutorizedPages;
using WASA_Mobile.Service;

namespace WASA_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public MainWindow()
        {
            InitializeComponent();
            logger.Info(Title + " initialized");
        }

        private async void authButton_Click(object sender, RoutedEventArgs e)
        {
            var user = await UserService.AuthUser(new() { Username = usernameBox.Text, Password = passswordBox.Password });
            if(user != null)
            {
                if(user.Id > 0)
                {
                    AuthorizeUserDataEntity.Id = user.Id;
                    switch (user.Role)
                    {
                        case Core.Const.RoleEnum.Seller:
                            break;
                        case Core.Const.RoleEnum.GrandSeller:
                            break;
                        case Core.Const.RoleEnum.Merchandiser:
                            break;
                        case Core.Const.RoleEnum.Director:
                            break;
                        case Core.Const.RoleEnum.Administrator:
                            logger.Info("Admin Auth");
                            var adminMain = new MainAdminWindow();
                            adminMain.Show();
                            Close();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Произошла ошибка при авторизации");
                    logger.Info("user id < 0");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Произошла ошибка при авторизации");
            }
        }
    }
}