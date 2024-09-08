using System.Windows;
using WASA_CoreLib.Entity;
using WASA_Desktop.AutorizedPages;
using WASA_Desktop.Service;

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
            logger.Info("App Started");
            logger.Info(Title + " initialized");
        }

        private async void authButton_Click(object sender, RoutedEventArgs e)
        {
            var user = await UserService.AuthUser(new() { Username = usernameBox.Text, Password = passswordBox.Password });
            if(user != null)
            {
                if(user.Id > 0)
                {
                    AuthorizedUserDataEntity.Id = user.Id;
                    AuthorizedUserDataEntity.Role = user.Role;
                    AuthorizedUserDataEntity.FIO = user.FIO;
                    AuthorizedUserDataEntity.CreateDate = user.CreateDate;
                    AuthorizedUserDataEntity.LastModifiedDate = user.LastModifiedDate;
                    AuthorizedUserDataEntity.Token = user.Token;
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
                            logger.Info($"Admin({user.Username}) Auth");
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
                    MessageBox.Show("Произошла ошибка при авторизации");
                    logger.Info("user id < 0");
                }
            }
            else
            {
                MessageBox.Show("Произошла ошибка при авторизации");
            }
        }
    }
}