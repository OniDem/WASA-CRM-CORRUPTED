using Core.Entity;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using WASA_CoreLib.Entity;
using WASA_Desktop.Service;

namespace WASA_Desktop.AutorizedPages
{
    /// <summary>
    /// Логика взаимодействия для ShiftWindow.xaml
    /// </summary>
    public partial class ShiftWindow : Window
    {
        private ShiftEntity currentShift = new();
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public ShiftWindow()
        {
            InitializeComponent();
            logger.Info(Title + " initialized");
            SharedDataEntity data = Task.Run(async () => await SharedDataService.GetData(new() { UserId = AuthorizedUserDataEntity.Id })).Result;
            try
            {
                if (data.OpenedShiftId > 0)
                {
                    currentShift = Task.Run(async () => await ShiftService.ShowById(new() { Id = data.OpenedShiftId })).Result;
                    Title = $"Текущая смена №{currentShift.Id}";
                    openShiftButton.IsEnabled = false;
                    insertCashButton.IsEnabled = true;
                    extractCashButton.IsEnabled = true;
                    acquiringApproveButton.IsEnabled = true;
                    closeShiftButton.IsEnabled = true;
                    dailyBillingLabel.Content = currentShift.Total;
                    cashBoxAmountLabel.Content = currentShift.Cash;
                    acquiringAmountLabel.Content = currentShift.Acquiring;
                    cashBoxAmountLabel.Content = currentShift.CashBox;
                    if (currentShift.AcquiringApproved == true)
                    {
                        acquiringAmountLabel.Content += "✓";
                    }
                }
                else
                {
                    Title = $"Текущая смена не открыта";
                    openShiftButton.IsEnabled = true;
                    dailyBillingLabel.Content = 0;
                    cashBoxAmountLabel.Content = 0;
                    acquiringAmountLabel.Content = 0;
                    cashBoxAmountLabel.Content = 0;
                }
                logger.Info($"Current shift id is {currentShift.Id}");
            }
            catch (Exception ex)
            {

                logger.Fatal($"Fatal Exception <{ex.Message}>");
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            var backWindow = new MainAdminWindow();
            backWindow.Show();
            Close();
            logger.Info(Title + " closed");
        }

        private async void openShiftButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentShift = await ShiftService.Open(new() { OpenBy = AuthorizedUserDataEntity.FIO, CashBox = 0/*AuthorizedUserDataEntity.LastShiftCashBox*/});
                logger.Info($"User opened shift {currentShift.Id}");
                if (currentShift != null)
                {
                    SharedDataEntity data = await SharedDataService.Update(new() { UserId = AuthorizedUserDataEntity.Id, OpenedShiftID = currentShift.Id, Barcode = "" });
                    logger.Info($" Shared data updated");
                    if (data.OpenedShiftId > 0)
                    {
                        openShiftButton.IsEnabled = false;
                        insertCashButton.IsEnabled = true;
                        extractCashButton.IsEnabled = true;
                        acquiringApproveButton.IsEnabled = true;
                        closeShiftButton.IsEnabled = true;

                        Title = $"Текущая смена №{currentShift.Id}";
                        dailyBillingLabel.Content = currentShift.Total;
                        cashBoxAmountLabel.Content = currentShift.Cash;
                        acquiringAmountLabel.Content = currentShift.Acquiring;
                        cashBoxAmountLabel.Content = currentShift.CashBox;
                    }
                    else
                    {
                        await ShiftService.Close(new() { Id = currentShift.Id, ClosedBy = AuthorizedUserDataEntity.FIO });
                        Title = $"Текущая смена не открыта";
                        openShiftButton.IsEnabled = true;
                        dailyBillingLabel.Content = 0;
                        cashBoxAmountLabel.Content = 0;
                        acquiringAmountLabel.Content = 0;
                        cashBoxAmountLabel.Content = 0;
                        logger.Info($"Shift closed because shared data doesn`t updated");
                    }

                }
            }
            catch (Exception ex)
            {

                logger.Fatal($"Fatal Exception <{ex.Message}>");
            }
        }

        private async void insertCashButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new DialogWindow("Введите сумму дня внесения в кассу");
                if (dialog.ShowDialog() == true)
                {
                    currentShift = await ShiftService.InsertCash(new() { Id = currentShift.Id, CashAmount = Convert.ToInt32(dialog.DialogText) });
                    dailyBillingLabel.Content = currentShift.Total;
                    cashBoxAmountLabel.Content = currentShift.Cash;
                    acquiringAmountLabel.Content = currentShift.Acquiring;
                    cashBoxAmountLabel.Content = currentShift.CashBox;
                    logger.Info($"User insert {dialog.DialogText}");
                }
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        private async void extractCashButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new DialogWindow("Введите сумму дня внесения в кассу");
                if (dialog.ShowDialog() == true)
                {
                    currentShift = await ShiftService.ExtractCash(new() { Id = currentShift.Id, CashAmount = Convert.ToInt32(dialog.DialogText) });
                    dailyBillingLabel.Content = currentShift.Total;
                    cashBoxAmountLabel.Content = currentShift.Cash;
                    acquiringAmountLabel.Content = currentShift.Acquiring;
                    cashBoxAmountLabel.Content = currentShift.CashBox;
                    logger.Info($"User extract {dialog.DialogText}");
                }
            }
            catch (Exception ex)
            {

                logger.Fatal($"Fatal Exception <{ex.Message}>");
            }

        }

        private async void acquiringApproveButton_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                if (acquiringAmountLabel.Content != null)
                {
                    if (acquiringAmountLabel.Content.ToString()!.Contains('✓'))
                    {
                        var res = MessageBox.Show("Хотите провести ещё одну сверку?", "", MessageBoxButton.OK);
                        if (res == MessageBoxResult.OK)
                        {
                            currentShift = await ShiftService.AcquiringApprove(new() { Id = currentShift.Id });
                            logger.Info($"User approve approved acquiring");
                        }
                    }
                    else
                    {
                        var res = MessageBox.Show($"Проведите сверку на оборудовании, если итог не равен {currentShift.Acquiring}, обратитесь к администратору", "", MessageBoxButton.OK);
                        if (res == MessageBoxResult.OK)
                            currentShift = await ShiftService.AcquiringApprove(new() { Id = currentShift.Id });
                        if (currentShift.AcquiringApproved == true)
                        {
                            acquiringAmountLabel.Content += "✓";
                            logger.Info($"User approve acquiring");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                logger.Fatal($"Fatal Exception <{ex.Message}>");
            }
        }

        private async void closeShiftButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (acquiringAmountLabel.Content.ToString()!.Contains('✓'))
                {
                    var res = MessageBox.Show("Вы уверены что хотите закрыть смену?", "", MessageBoxButton.OK);
                    if (res == MessageBoxResult.OK)
                    {
                        currentShift = await ShiftService.Close(new() { Id = currentShift.Id, ClosedBy = AuthorizedUserDataEntity.FIO });
                        if (currentShift.Closed == true)
                        {
                            SharedDataEntity data = await SharedDataService.Update(new() { UserId = AuthorizedUserDataEntity.Id, OpenedShiftID = -1, Barcode = "" });
                            Title = $"Текущая смена не открыта";
                            openShiftButton.IsEnabled = true;
                            openShiftButton.Opacity = 1;
                            insertCashButton.IsEnabled = false;
                            insertCashButton.Opacity = 0.5;
                            extractCashButton.IsEnabled = false;
                            extractCashButton.Opacity = 0.5;
                            acquiringApproveButton.IsEnabled = false;
                            acquiringApproveButton.Opacity = 0.5;
                            closeShiftButton.IsEnabled = false;
                            closeShiftButton.Opacity = 0.5;
                            AuthorizedUserDataEntity.LastShiftCashBox = currentShift.CashBox.Value;
                            dailyBillingLabel.Content = "0";
                            cashBoxAmountLabel.Content = "0";
                            acquiringAmountLabel.Content = "0";
                            //AuthorizedUserDataEntity.LastShiftCashBox;
                            logger.Info($"User closed shift {currentShift.Id}");

                        }
                    }
                }
                else
                {
                    //StatusLabel
                }
            }
            catch (Exception ex)
            {

                logger.Fatal($"Fatal Exception <{ex.Message}>");
            }
        }
    }
}
