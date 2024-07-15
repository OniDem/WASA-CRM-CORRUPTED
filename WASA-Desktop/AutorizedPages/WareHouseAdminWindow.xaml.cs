using Core.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using WASA_Mobile.Service;

namespace WASA_Desktop.AutorizedPages
{
    /// <summary>
    /// Логика взаимодействия для WareHouseAdminWindow.xaml
    /// </summary>
    public partial class WareHouseAdminWindow : Window
    {
        private List<CategoryShowEntity>? _categories = new();
        private string? _category = "";
        DispatcherTimer timer = new();
        private bool _autoBarcodeUpdate = false;
        public WareHouseAdminWindow()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);//hh,mm,ss

            Dispatcher.Invoke(async () =>
            {
                productsDG.ItemsSource = await ProductService.GetAllProducts();
                _categories = await CategoryService.GetAll();
                for (int i = 0; i < _categories!.Count(); i++)
                {
                    RadioButton radioButton = new()
                    {
                        GroupName = "Category",
                        Content = _categories![i].CategoryName,
                        Margin = new(2)
                    };
                    radioButton.Click += RadioButton_Click;
                    categoryStackPanel.Children.Add(radioButton);
                }
            });
            
        }

        private async void Timer_Tick(object? sender, EventArgs e)
        {
            if(_autoBarcodeUpdate)
            {
                var data = await SharedDataService.GetData(new() { UserId = AuthorizeUserDataEntity.Id });
                if (data != null)
                {
                    if(data.Barcode != null)
                    {
                        barcodeBox.Text = data.Barcode;
                    }
                }
                else
                    MessageBox.Show("При получении данных произошла ошибка");
            }
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            _category = (sender as RadioButton).Content.ToString();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            var backWindow = new MainAdminWindow();
            backWindow.Show();
            Close();
        }

        private async void barcodeBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(barcodeBox.Text.Length == 13)
            {
                var product = await ProductService.SearchProduct(new() {  ProductCode = barcodeBox.Text });
                if(product != null)
                {
                    if(product.ProductCode == barcodeBox.Text)
                    {
                        statusLabel.Content = "Продукт уже существует";
                        statusLabel.Foreground = Brushes.Red;
                        statusLabel.Visibility = Visibility.Visible;
                        await Task.Delay(1 * 1000); //1 - seconds count
                        statusLabel.Visibility = Visibility.Hidden;

                        addButton.IsEnabled = false;
                    }
                    else
                        addButton.IsEnabled = true;
                }
            }
        }

        private async void addButton_Click(object sender, RoutedEventArgs e)
        {
            if(barcodeBox.Text.Length == 13)
            {
                if(nameBox.Text.Length > 0)
                {
                    if(_category.Length > 0)
                    {
                        if(priceBox.Text.Length > 0)
                        {
                            if(countBox.Text.Length > 0)
                            {
                                var product = await ProductService.AddProduct(new() { ProductCode = barcodeBox.Text, ProductName = nameBox.Text, Category = _category, Price = Convert.ToInt32(priceBox.Text), Count = Convert.ToInt32(countBox.Text) });
                                if(product != null)
                                {
                                    if(product.ProductCode.Length > 0)
                                    {
                                        statusLabel.Content = "Товар успешно добавлен";
                                        statusLabel.Foreground = Brushes.LimeGreen;
                                        statusLabel.Visibility = Visibility.Visible;
                                        barcodeBox.Text = "";
                                        nameBox.Text = "";
                                        priceBox.Text = "";
                                        countBox.Text = "";
                                        await Dispatcher.Invoke(async () =>
                                        {
                                            productsDG.ItemsSource = await ProductService.GetAllProducts();
                                        });
                                        await Task.Delay(1 * 1000); //1 - seconds count
                                        statusLabel.Visibility = Visibility.Hidden;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private async void getCodeButton_Click(object sender, RoutedEventArgs e)
        {
            var data = await SharedDataService.GetData(new() { UserId = AuthorizeUserDataEntity.Id });
            if(data != null)
            {
                if(data.Barcode != null)
                {
                    barcodeBox.Text = data.Barcode;
                    data = await SharedDataService.Update(new() { UserId = data.UserId, Barcode = barcodeBox.Text });
                }
                else
                {
                    statusLabel.Content = "Код не был отправлен";
                    statusLabel.Foreground = Brushes.Red;
                    statusLabel.Visibility = Visibility.Visible;
                    await Task.Delay(1 * 1000); //1 - seconds count
                    statusLabel.Visibility = Visibility.Hidden;
                }
            }
            else
                MessageBox.Show("При получении данных произошла ошибка");
        }

        private async void barcodeBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var data = await SharedDataService.GetData(new() { UserId = AuthorizeUserDataEntity.Id });
            if (data != null)
            {
                if (data.Barcode != null)
                {
                    barcodeBox.Text = data.Barcode;
                    data = await SharedDataService.Update(new() { UserId = data.UserId, Barcode = barcodeBox.Text });
                }
                else
                {
                    statusLabel.Content = "Код не был отправлен";
                    statusLabel.Foreground = Brushes.Red;
                    statusLabel.Visibility = Visibility.Visible;
                    await Task.Delay(1 * 1000); //1 - seconds count
                    statusLabel.Visibility = Visibility.Hidden;
                }
            }
            else
                MessageBox.Show("При получении данных произошла ошибка");
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void autoCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            _autoBarcodeUpdate = true;
        }

        private void autoCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            _autoBarcodeUpdate = true;
        }
    }
}
