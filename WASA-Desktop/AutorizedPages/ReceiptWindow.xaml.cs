﻿using Core.Const;
using Core.Entity;
using DTO.Receipt;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using WASA_CoreLib.Entity;
using WASA_Desktop.Service;

namespace WASA_Desktop.AutorizedPages
{
    /// <summary>
    /// Логика взаимодействия для ReceiptWindow.xaml
    /// </summary>
    public partial class ReceiptWindow : Window
    {
        private ReceiptEntity _currentReceipt = new();
        private ProductEntity _currentProduct = new();
        private readonly int _timerTime = 1 * 1000; //multiplier(1sec=1000ms) 
        DispatcherTimer timer = new();
        private bool _autoBarcodeUpdate = false;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public ReceiptWindow()
        {
            InitializeComponent();
            logger.Info(Title + " initialized");
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, _timerTime);//hh,mm,ss
            logger.Info($"Timer created with interval {_timerTime}ms");
            ///
            var data = Task.Run(async () => await SharedDataService.GetData(new() { UserId = AuthorizedUserDataEntity.Id })).Result;
            AuthorizedUserDataEntity.ShiftId = data.OpenedShiftId;
            logger.Info($"Shift id is {data.OpenedShiftId}");
            if (data.OpenedShiftId < 1)
            {
                getCodeButton.IsEnabled = false;
                autoCheckBox.IsEnabled = false;
                addButton.IsEnabled = false;
                cashButton.IsEnabled = false;
                acquiringButton.IsEnabled = false;
            }
            ///
        }

        private async void Timer_Tick(object? sender, EventArgs e)
        {
            if (_autoBarcodeUpdate)
            {
                var data = await SharedDataService.GetData(new() { UserId = AuthorizedUserDataEntity.Id });
                if (data != null)
                    if (data.Barcode != null)
                        barcodeBox.Text = data.Barcode;
                    else
                        DisplayStatus("error", _timerTime, "При получении штрихкода произошла ошибка");
                logger.Info($"Barcode data catched from other device");
            }
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_currentReceipt != null)
                if (_currentReceipt.Id > 0)
                    if (!_currentReceipt.Closed)
                    {
                        e.Cancel = true;
                        DisplayStatus("warning", _timerTime, "Проведите оплату, либо отмените чек");
                        logger.Info(Title + $" close canceled, because receipt not closed");
                    }
            logger.Info(Title + $"closed");
        }

        private async void cashButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayStatus("warning", _timerTime, "Производится синхронизация оплаты");
            var receipt = await ReceiptService.Payment(new() { Id = _currentReceipt.Id, PayMethod = PayMethodEnum.Cash, PaymentDate = DateTime.UtcNow, Total = _currentReceipt.Total });
            logger.Info($"Receipt №{receipt.Id} paid by cash");
            if (receipt.Id > 0)
            {
                _currentReceipt = receipt;
                receipt = await ReceiptService.Close(new() { Id = _currentReceipt.Id });
                logger.Info($"Receipt №{receipt.Id} closed");
                if (receipt.Id > 0)
                {
                    await ShiftService.AddReceiptToShift(new() { ReceiptId = receipt.Id, Cash = receipt.Total, Acquiring = 0, Total = receipt.Total, Id = Convert.ToInt32(AuthorizedUserDataEntity.ShiftId) });
                    DisplayStatus("good", _timerTime, "Чек успешно закрыт");
                    logger.Info($"Receipt №{receipt.Id} added to shift №{AuthorizedUserDataEntity.ShiftId}");
                    _currentProduct = new();
                    barcodeBox.Text = "";
                    cashButton.IsEnabled = false;
                    acquiringButton.IsEnabled = false;
                    _currentReceipt = new()
                    {
                        Id = -1,
                        ProductCodes = [],
                        ProductCategories = [],
                        ProductNames = [],
                        ProductCount = [],
                        ProductPrices = [],
                        PayMethod = PayMethodEnum.Cash,
                        Total = 0,
                        Seller = "",
                    };

                    totalLabel.Content = "";
                    receiptDG.ItemsSource = await FillReceiptDGFromReceipt(_currentReceipt);
                    
                }
            }
        }

        private async void acquiringButton_Click(object sender, RoutedEventArgs e)
        {
            DisplayStatus("warning", _timerTime, "Производится синхронизация оплаты");
            var receipt = await ReceiptService.Payment(new() { Id = _currentReceipt.Id, PayMethod = PayMethodEnum.Acquiring, PaymentDate = DateTime.UtcNow, Total = _currentReceipt.Total });
            logger.Info($"Receipt №{receipt.Id} paid by acquiring");
            if (receipt.Id > 0)
            {
                _currentReceipt = receipt;
                receipt = await ReceiptService.Close(new() { Id = _currentReceipt.Id });
                logger.Info($"Receipt №{receipt.Id} closed");
                if (receipt.Id > 0)
                {
                    await ShiftService.AddReceiptToShift(new() { ReceiptId = receipt.Id, Cash = 0, Acquiring = receipt.Total, Total = receipt.Total, Id = Convert.ToInt32(AuthorizedUserDataEntity.ShiftId) });
                    DisplayStatus("good", _timerTime, "Чек успешно закрыт");
                    logger.Info($"Receipt №{receipt.Id} added to shift №{AuthorizedUserDataEntity.ShiftId}");
                    _currentProduct = new();
                    barcodeBox.Text = "";
                    cashButton.IsEnabled = false;
                    acquiringButton.IsEnabled = false;
                    _currentReceipt = new()
                    {
                        Id = -1,
                        ProductCodes = [],
                        ProductCategories = [],
                        ProductNames = [],
                        ProductCount = [],
                        ProductPrices = [],
                        PayMethod = PayMethodEnum.Cash,
                        Total = 0,
                        Seller = "",
                    };
                    totalLabel.Content = "";
                    receiptDG.ItemsSource = await FillReceiptDGFromReceipt(_currentReceipt);
                    
                }
            }
        }

        private async void getCodeButton_Click(object sender, RoutedEventArgs e)
        {
            var data = await SharedDataService.GetData(new() { UserId = AuthorizedUserDataEntity.Id });
            if (data != null)
            {
                if (data.Barcode != null)
                {
                    barcodeBox.Text = data.Barcode;
                    data = await SharedDataService.Update(new() { UserId = data.UserId, Barcode = barcodeBox.Text });
                    logger.Info($"Get barcode:{data.Barcode} from other device");
                }
                else
                {
                    DisplayStatus("error", _timerTime, "Код не был отправлен");
                    logger.Info($"Barcode don`t sended");
                }
                }
        }

        private async void barcodeBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (barcodeBox.Text.Length == 13)
            {
                logger.Info($"Search product with barcode:{barcodeBox.Text}");
                _currentProduct = await ProductService.SearchProduct(new() { ProductCode = barcodeBox.Text });
                if (_currentProduct != null)
                {
                    logger.Info($"Product finded");
                    nameBox.Text = _currentProduct.ProductName;
                    priceBox.Text = _currentProduct.Price.ToString();
                    countBox.Text = "1";
                }
                else
                {
                    DisplayStatus("error", _timerTime, "Продукта не существует");
                    logger.Info($"Product don`t exist");
                }

            }
            else if (barcodeBox.Text.Length == 0)
            {
                nameBox.Text = "";
                priceBox.Text = "";
                countBox.Text = "";
            }
        }

        private void autoCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            _autoBarcodeUpdate = true;
            logger.Info($"Auto getting code active");
        }

        private void autoCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            _autoBarcodeUpdate = false;
            logger.Info($"Auto getting code deactive");
        }

        private async void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (barcodeBox.Text.Length > 0)
            {
                if (nameBox.Text.Length > 0)
                {
                    if (countBox.Text.Length > 0)
                    {
                        if (priceBox.Text.Length > 0)
                        {
                            _currentProduct.Count = Convert.ToInt32(countBox.Text);
                            if (_currentReceipt.Id < 1)
                            {
                                DisplayStatus("warning", _timerTime, "Идёт создание чека");
                                _currentReceipt = await ReceiptService.AddReceipt(new()
                                {
                                    ProductCodes = [_currentProduct.ProductCode],
                                    ProductNames = [nameBox.Text],
                                    ProductCounts = [Convert.ToDouble(countBox.Text)],
                                    ProductPrices = [Convert.ToDouble(priceBox.Text)],
                                    PayMethod = PayMethodEnum.Cash,
                                    Total = Convert.ToDouble(countBox.Text) * Convert.ToDouble(priceBox.Text),
                                    Seller = AuthorizedUserDataEntity.FIO!
                                });
                                logger.Info($"User create receipt №{_currentReceipt.Id} with product(barcode:{_currentProduct.ProductCode}");
                                receiptDG.ItemsSource = await FillReceiptDGFromReceipt(await ReceiptService.GetReceiptById(new() { Id = _currentReceipt.Id }));
                                DisplayStatus("good", _timerTime, "Чек создан");
                                totalLabel.Content = "Итого: " + _currentReceipt.Total.ToString();
                                cashButton.IsEnabled = true;
                                acquiringButton.IsEnabled = true;
                            }
                            else
                            {
                                DisplayStatus("warning", _timerTime, "Добавление продукта");
                                AddProductToReceiptRequest request = new() { Id = 0, ProductCodes = [], ProductNames = [], ProductCounts = [], ProductPrices = [] };
                                request.Id = _currentReceipt.Id;
                                request.ProductCodes.Add(_currentProduct.ProductCode);
                                request.ProductNames.Add(nameBox.Text);
                                request.ProductCounts.Add(Convert.ToDouble(countBox.Text));
                                request.ProductPrices.Add(Convert.ToDouble(priceBox.Text));

                                _currentReceipt = await ReceiptService.AddProductToReceipt(request);
                                logger.Info($"User add product(barcode:{_currentProduct.ProductCode}) to receipt №{_currentReceipt.Id}");
                                receiptDG.ItemsSource = await FillReceiptDGFromReceipt(await ReceiptService.GetReceiptById(new() { Id = _currentReceipt.Id }));
                                DisplayStatus("good", _timerTime, "Продукт успешно добавлен");
                                totalLabel.Content = "Итого: " + _currentReceipt.Total.ToString();
                                cashButton.IsEnabled = true;
                                acquiringButton.IsEnabled = true;
                            }
                        }
                    }
                }
            }
        }

        private async Task<List<ProductEntity>> FillReceiptDGFromReceipt(ReceiptEntity receipt)
        {
            List<ProductEntity> listToReturn = new();
            if (receipt != null)
            {
                if (receipt.Id > 0)
                {
                    for (int i = 0; i < receipt.ProductCodes!.Count; i++)
                    {
                        ProductEntity product = new() 
                        {
                            ProductCode = receipt.ProductCodes[i],
                            Category = receipt.ProductCategories[i],
                            ProductName = receipt.ProductNames[i],
                            Count = receipt.ProductCount![i],
                            Price = receipt.ProductPrices![i],

                        };
                        listToReturn.Add(product);
                    }
                }
            }
            logger.Info($"DataGrid updated with {listToReturn.Count} items");
            return listToReturn;
        }


        private async void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (_currentReceipt != null)
            {
                if (_currentReceipt.Id > 0)
                {
                    if (_currentReceipt.Closed)
                    {
                        var backWindow = new MainAdminWindow();
                        backWindow.Show();
                        Close();
                        logger.Info(Title + "closed");
                    }
                    else
                    {
                        DisplayStatus("error", _timerTime, "Проведите оплату, либо отмените чек");
                        logger.Info($"Closing canceled");
                    }
                }
                else
                {
                    var backWindow = new MainAdminWindow();
                    backWindow.Show();
                    Close();
                }
            }
            else
            {
                var backWindow = new MainAdminWindow();
                backWindow.Show();
                Close();
            }
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

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        
    }
}
