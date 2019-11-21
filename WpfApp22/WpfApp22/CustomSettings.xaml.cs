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

namespace WpfApp22
{
    /// <summary>
    /// Interaction logic for CustomSettings.xaml
    /// </summary>
    public partial class CustomSettings : Window
    {
        int xamlCustomHeight;
        int xamlCustomWight;
        int xamlMines;
        String modeMines;

        public CustomSettings()
        {
            InitializeComponent();
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
            var item = sender as TextBox;
            xamlCustomWight = int.Parse(item.Text);
        }

        private void height_TextChanged(object sender, TextChangedEventArgs e)
        {
            var item = sender as TextBox;
            xamlCustomHeight = int.Parse(item.Text);
        }

        private void mines_TextChanged(object sender, TextChangedEventArgs e)
        {
            var item = sender as TextBox;
            xamlMines = int.Parse(item.Text);
        }

        private void Radio_btn_Checked(object sender, RoutedEventArgs e)
        {
            if (Auto_visible.IsChecked == true)
                modeMines = "Auto_visible";
            else if (Auto_hide.IsChecked == true)
                modeMines = "Auto_hide";
            else if (Adjusted.IsChecked == true)
                modeMines = "Adjusted";
        }
    }
}
