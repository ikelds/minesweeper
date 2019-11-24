using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace WpfApp22
{

    public partial class CustomSettings : Window, INotifyPropertyChanged
    {
        int xamlCustomHeight;
        int xamlCustomWight;
        int xamlMines;
        String modeMines;
        Regex regex = new Regex("^[0-9]+$");

        public CustomSettings()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void GenerateQuantityMines()
        {
            int multiplier;
            int numberOfMines;

            Random r = new Random();
            multiplier = r.Next(6, 11);
            numberOfMines = xamlCustomHeight * xamlCustomWight / multiplier;

            xamlMines = numberOfMines;
        }

        private void Button_Cust_OK(object sender, RoutedEventArgs e)
        {
            MainWindow.heightSize = xamlCustomHeight;
            MainWindow.widthSize = xamlCustomWight;

            var myMainWindow = this.Owner as MainWindow;

            if (modeMines == "Auto_visible")
            {
                GenerateQuantityMines();
                myMainWindow.cntLabel.Visibility = Visibility.Visible;
                
            }                
            else if (modeMines == "Auto_hide")
            {
                GenerateQuantityMines();
                myMainWindow.cntLabel.Visibility = Visibility.Hidden;
            }
            else if(modeMines == "Adjusted")
            {
                MainWindow.mines = xamlMines;
                myMainWindow.cntLabel.Visibility = Visibility.Visible;
            }

            MainWindow.mines = xamlMines;
            myMainWindow.NewGame(); 
            this.Close();
        }

        private void Button_Cust_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void width_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBoxXaml = sender as TextBox;

            if (regex.IsMatch(textBoxXaml.Text))
            {
                int valueTxtBox = int.Parse(textBoxXaml.Text);

                if (valueTxtBox > 100)
                {
                    if (MessageBox.Show("Введеное значение слишком велико. " +
                        "Создание большого игрового поля может занять " +
                        "значительное время. Вы уверены, что хотите продолжить?", 
                        "Предупреждение", MessageBoxButton.YesNo, 
                        MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        xamlCustomWight = valueTxtBox;
                    }
                    else
                    {
                        textBoxXaml.Text = xamlCustomWight.ToString();
                    }
                }
                else
                {
                    xamlCustomWight = valueTxtBox;
                }
            }
        }

        private void height_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBoxXaml = sender as TextBox;

            if (regex.IsMatch(textBoxXaml.Text))
            {
                int valueTxtBox = int.Parse(textBoxXaml.Text);

                if (valueTxtBox > 100)
                {
                    if (MessageBox.Show("Введеное значение слишком велико. " +
                        "Создание большого игрового поля может занять " +
                        "значительное время. Вы уверены, что хотите продолжить?",
                        "Предупреждение", MessageBoxButton.YesNo,
                        MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        xamlCustomHeight = valueTxtBox;
                    }
                    else
                    {
                        textBoxXaml.Text = xamlCustomWight.ToString();
                    }
                }
                else
                {
                    xamlCustomHeight = valueTxtBox;
                }
            }
        }

        private void mines_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBoxXaml = sender as TextBox;

            if (regex.IsMatch(textBoxXaml.Text))
            {
                int valueTxtBox = int.Parse(textBoxXaml.Text);

                if (valueTxtBox >= xamlCustomHeight * xamlCustomWight)
                {
                    MessageBox.Show("Количество мин больше либо равно, общего числа клеток на поле. " +
                        "Уменьшите количество мин.", "Предупреждение");
                    textBoxXaml.Text = xamlMines.ToString();
                }
                else
                {
                    xamlMines = valueTxtBox;
                }
            }
            else
            {
                MessageBox.Show("Неверное значение количества мин.", "Ошибка");
            }
        }

        private void Radio_btn_Checked(object sender, RoutedEventArgs e)
        {
            if (Auto_visible.IsChecked == true)
            {
                modeMines = "Auto_visible";
                TextBoxEnabled = false;
                TextBoxEnabled = false;
            }
            else if (Auto_hide.IsChecked == true)
            {
                modeMines = "Auto_hide";
                TextBoxEnabled = false;
            }
            else if (Adjusted.IsChecked == true)
            {
                modeMines = "Adjusted";
                TextBoxEnabled = true;
            }
        }

        private Boolean _textbox_enabled;
        
        public Boolean TextBoxEnabled
        {
            get { return _textbox_enabled; }
            set
            {
                _textbox_enabled = value;
                OnPropertyChanged("TextBoxEnabled");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
