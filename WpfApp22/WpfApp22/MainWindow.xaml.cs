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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp22
{
    public partial class MainWindow : Window
    {
        public static int heightSize;
        public static int widthSize;
        public static int mines;
        Rectangle[,] rect;
        ImageBrush ib;
        int[,] arrMines;
        int[,] arrCntMines;        
        int[,] arrCurrentStateGame;
        int[,] arrProcessed;
        int[,] arrFlags;

        Mines mns = new Mines();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = mns;
        }

        public void NewGame()
        {
            arrMines = new int[heightSize, widthSize];
            arrCurrentStateGame = new int[heightSize, widthSize];
            arrProcessed = new int[heightSize, widthSize];
            arrFlags = new int[heightSize, widthSize];
            bool checkSettings;
            checkSettings = SetMines(heightSize, widthSize, mines);
            
            mns.MinesProp = mines;

            if (checkSettings)
            {
                Clear();
          
                ib = new ImageBrush();
                BitmapImage bmi = new BitmapImage(new Uri(@"pack://application:,,,/Images/flag.jpg"));
                ib.ImageSource = bmi;

                for (int i = 0; i < heightSize; i++)
                {
                    gridField.RowDefinitions.Add(
                        new RowDefinition() { Height = new GridLength(31) });
                }

                for (int j = 0; j < widthSize; j++)
                {
                    gridField.ColumnDefinitions.Add(
                        new ColumnDefinition() { Width = new GridLength(31) });
                }

                rect = new Rectangle[heightSize, widthSize];
                for (int i = 0; i < heightSize; i++)
                {
                    for (int j = 0; j < widthSize; j++)
                    {
                        rect[i, j] = new Rectangle();
                        Grid.SetColumn(rect[i, j], j);
                        Grid.SetRow(rect[i, j], i);
                        rect[i, j].PreviewMouseLeftButtonUp += this.rect_LeftMouseDown;
                        rect[i, j].MouseRightButtonDown += this.rect_RightMouseDown;
                        rect[i, j].Stroke = Brushes.Black;
                        rect[i, j].StrokeThickness = 0.09;
                        rect[i, j].Height = 30;
                        rect[i, j].Width = 30;
                        rect[i, j].Fill = Brushes.LightGray;
                        gridField.Children.Add(rect[i, j]);
                    }
                }

                CountMineAround();
            }
            else
            {
                MessageBox.Show("Исправьте параметры");
            }
        }

        private void RefreshAllRects()
        {
            for (int i = 0; i < heightSize; i++)
            {
                for (int j = 0; j < widthSize; j++)
                {
                    if (arrCurrentStateGame[i, j] == 1111 && rect[i, j].Fill != Brushes.LightGray)
                        rect[i, j].Fill = Brushes.LightGray;
                    else if (arrCurrentStateGame[i, j] == 0 && rect[i, j].Fill != Brushes.White)
                        rect[i, j].Fill = Brushes.White;
                    else if (arrCurrentStateGame[i, j] == 5555)
                        rect[i, j].Fill = ib;
                    else if (arrCurrentStateGame[i, j] == 9999 && rect[i, j].Fill != Brushes.Red)
                        rect[i, j].Fill = Brushes.Red;
                    else if (arrCurrentStateGame[i, j] > 0 && arrCurrentStateGame[i, j] <= 8 && arrProcessed[i, j] == 0)
                    {
                        rect[i, j].Fill = Brushes.White;
                        TextBlock txtTorect = new TextBlock();
                        txtTorect.VerticalAlignment = VerticalAlignment.Center;
                        txtTorect.HorizontalAlignment = HorizontalAlignment.Center;
                        txtTorect.Text = arrCurrentStateGame[i, j].ToString();
                        Grid.SetRow(txtTorect, i);
                        Grid.SetColumn(txtTorect, j);
                        gridField.Children.Add(txtTorect);
                        arrProcessed[i, j] = 1;
                    }
                }
            }
        }

        private void SettingFlag(int i, int j, Rectangle currrect)
        {

            if (arrMines != null)
            {
                if (arrCurrentStateGame[i, j] == 1111)
                {
                    arrCurrentStateGame[i, j] = 5555;
                    arrFlags[i, j] = 99;
                    mns.MinesProp--;
                }
                else if (arrCurrentStateGame[i, j] == 5555)
                {
                    arrCurrentStateGame[i, j] = 1111;
                    arrFlags[i, j] = 0;
                    mns.MinesProp++;
                }
            }
            else
                MessageBox.Show("Сначала нажмите кнопку \"Начать игру\"");
            
            RefreshAllRects();
            GameCompletionCheck();
        }

        private void ShowSumMinesAroundEmptyRect()
        {
            int i_offset;
            int j_offset;

            for (int i = 0; i < heightSize; i++)
            {
                for (int j = 0; j < widthSize; j++)
                {
                    if (arrCurrentStateGame[i, j] == 0)
                    {
                        i_offset = i - 1;
                        j_offset = j - 1;
                        if (i_offset >= 0 && j_offset >= 0)
                            if ((arrCntMines[i_offset, j_offset] > 0) && (arrCntMines[i_offset, j_offset] <= 8))
                                arrCurrentStateGame[i_offset, j_offset] = arrCntMines[i_offset, j_offset];

                        i_offset = i - 1;
                        j_offset = j;
                        if (i_offset >= 0)
                            if ((arrCntMines[i_offset, j_offset] > 0) && (arrCntMines[i_offset, j_offset] <= 8))
                                arrCurrentStateGame[i_offset, j_offset] = arrCntMines[i_offset, j_offset];

                        i_offset = i - 1;
                        j_offset = j + 1;
                        if (i_offset >= 0 && j_offset < widthSize)
                            if ((arrCntMines[i_offset, j_offset] > 0) && (arrCntMines[i_offset, j_offset] <= 8))
                                arrCurrentStateGame[i_offset, j_offset] = arrCntMines[i_offset, j_offset];

                        i_offset = i;
                        j_offset = j - 1;
                        if (j_offset >= 0)
                            if ((arrCntMines[i_offset, j_offset] > 0) && (arrCntMines[i_offset, j_offset] <= 8))
                                arrCurrentStateGame[i_offset, j_offset] = arrCntMines[i_offset, j_offset];

                        i_offset = i;
                        j_offset = j + 1;
                        if (j_offset < widthSize)
                            if ((arrCntMines[i_offset, j_offset] > 0) && (arrCntMines[i_offset, j_offset] <= 8))
                                arrCurrentStateGame[i_offset, j_offset] = arrCntMines[i_offset, j_offset];

                        i_offset = i + 1;
                        j_offset = j - 1;
                        if (i_offset < heightSize && j_offset >= 0)
                            if ((arrCntMines[i_offset, j_offset] > 0) && (arrCntMines[i_offset, j_offset] <= 8))
                                arrCurrentStateGame[i_offset, j_offset] = arrCntMines[i_offset, j_offset];

                        i_offset = i + 1;
                        j_offset = j;
                        if (i_offset < heightSize)
                            if ((arrCntMines[i_offset, j_offset] > 0) && (arrCntMines[i_offset, j_offset] <= 8))
                                arrCurrentStateGame[i_offset, j_offset] = arrCntMines[i_offset, j_offset];

                        i_offset = i + 1;
                        j_offset = j + 1;
                        if (i_offset < heightSize && j_offset < widthSize)
                            if ((arrCntMines[i_offset, j_offset] > 0) && (arrCntMines[i_offset, j_offset] <= 8))
                                arrCurrentStateGame[i_offset, j_offset] = arrCntMines[i_offset, j_offset];
                    }
                }
            }
        }

        private void IfEmptyRectProcessOtherRect(int i, int j)
        {
            arrCurrentStateGame[i, j] = 0;
            int i_offset;
            int j_offset;

            try
            {
                i_offset = i - 1;
                j_offset = j - 1;
                if ((i_offset >= 0) && (j_offset >= 0) && (arrCntMines[i_offset, j_offset] == 0) && (arrCurrentStateGame[i_offset, j_offset] == 1111))
                    IfEmptyRectProcessOtherRect(i_offset, j_offset);

                i_offset = i - 1;
                j_offset = j;
                if ((i_offset >= 0) && (arrCntMines[i_offset, j_offset] == 0) && (arrCurrentStateGame[i_offset, j_offset] == 1111))
                    IfEmptyRectProcessOtherRect(i_offset, j_offset);

                i_offset = i - 1;
                j_offset = j + 1;
                if ((i_offset >= 0) && j_offset < widthSize && (arrCntMines[i_offset, j_offset] == 0) && (arrCurrentStateGame[i_offset, j_offset] == 1111))
                    IfEmptyRectProcessOtherRect(i_offset, j_offset);

                i_offset = i;
                j_offset = j - 1;
                if ((j_offset >= 0) && (arrCntMines[i_offset, j_offset] == 0) && (arrCurrentStateGame[i_offset, j_offset] == 1111))
                    IfEmptyRectProcessOtherRect(i_offset, j_offset);

                i_offset = i;
                j_offset = j + 1;
                if ((j_offset < widthSize) && (arrCntMines[i_offset, j_offset] == 0) && (arrCurrentStateGame[i_offset, j_offset] == 1111))
                    IfEmptyRectProcessOtherRect(i_offset, j_offset);

                i_offset = i + 1;
                j_offset = j - 1;
                if ((i_offset < heightSize) && (j_offset >= 0) && (arrCntMines[i_offset, j_offset] == 0) && (arrCurrentStateGame[i_offset, j_offset] == 1111))
                    IfEmptyRectProcessOtherRect(i_offset, j_offset);

                i_offset = i + 1;
                j_offset = j;
                if ((i_offset < heightSize) && (arrCntMines[i_offset, j_offset] == 0) && (arrCurrentStateGame[i_offset, j_offset] == 1111))
                    IfEmptyRectProcessOtherRect(i_offset, j_offset);

                i_offset = i + 1;
                j_offset = j + 1;
                if ((i_offset < heightSize) && (j_offset < widthSize) && (arrCntMines[i_offset, j_offset] == 0) && (arrCurrentStateGame[i_offset, j_offset] == 1111))
                    IfEmptyRectProcessOtherRect(i_offset, j_offset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ShowSumMinesAroundEmptyRect();
            RefreshAllRects();
        }

        private void rect_RightMouseDown(object sender, MouseButtonEventArgs e)
        {
            var currrect = sender as Rectangle;

            int rect_i = Grid.GetRow(currrect);
            int rect_j = Grid.GetColumn(currrect);

            SettingFlag(rect_i, rect_j, currrect);
        }

        private void rect_LeftMouseDown(object sender, MouseButtonEventArgs e)
        {
            var currrect = sender as Rectangle;
            int totalMines;

            int rect_i = Grid.GetRow(currrect);
            int rect_j = Grid.GetColumn(currrect);

            totalMines = arrCntMines[rect_i, rect_j];
            
            if (arrMines != null)
            {
                if  (arrCurrentStateGame[rect_i, rect_j] != 5555)
                {
                    if (arrMines[rect_i, rect_j] == 99)
                    {
                        arrCurrentStateGame[rect_i, rect_j] = 9999;
                    }
                    else if (totalMines == 0)
                    {
                        try
                        {
                            IfEmptyRectProcessOtherRect(rect_i, rect_j);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        arrCurrentStateGame[rect_i, rect_j] = totalMines;
                    }
                }
            }
            else
                MessageBox.Show("Сначала нажмите кнопку \"Начать игру\"");
                        
            RefreshAllRects();
        }

        private bool SetMines(int heightSize, int widthSize, int numberMines)
        {
            if (numberMines >= heightSize * widthSize)
            {
                MessageBox.Show("Количество мин больше или равно, общего числа клеток на поле. Уменьшите количество мин.", "Предупреждение");

                return false;
            }
            else
            {
                InitialStateArrCurrentStateGame();
                Random r = new Random();
                int countMines = 0;
                int i;
                int j;

                while (countMines != numberMines)
                {

                    i = r.Next(0, heightSize);
                    j = r.Next(0, widthSize);

                    if (arrMines[i, j] != 99)
                    {
                        arrMines[i, j] = 99;
                        countMines++;
                    }
                }

                return true;
            }
        }

        private void CountMineAround()
        {
            arrCntMines = new int[heightSize, widthSize];
            int sumMines;
            int i_offset;
            int j_offset; 

            for (int i = 0; i < heightSize; i++)
            {
                for (int j = 0; j < widthSize; j++)
                {                    
                    sumMines = 0;

                    i_offset = i - 1;
                    j_offset = j - 1;
                    if ((i_offset >= 0) && (j_offset >= 0) && (arrMines[i_offset, j_offset] == 99))
                        sumMines ++;

                    i_offset = i - 1;
                    j_offset = j;
                    if ((i_offset >= 0) && (arrMines[i_offset, j_offset] == 99))
                        sumMines++;

                    i_offset = i - 1;
                    j_offset = j + 1;
                    if ((i_offset >= 0) && j_offset < widthSize && (arrMines[i_offset, j_offset] == 99))
                        sumMines++;

                    i_offset = i;
                    j_offset = j - 1;
                    if ((j_offset >= 0) && (arrMines[i_offset, j_offset] == 99))
                        sumMines++;

                    i_offset = i;
                    j_offset = j + 1;
                    if ((j_offset < widthSize) && (arrMines[i_offset, j_offset] == 99))
                        sumMines++;

                    i_offset = i + 1;
                    j_offset = j - 1;
                    if ((i_offset < heightSize) && (j_offset >= 0) && (arrMines[i_offset, j_offset] == 99))
                        sumMines++;

                    i_offset = i + 1;
                    j_offset = j;
                    if ((i_offset < heightSize) && (arrMines[i_offset, j_offset] == 99))
                        sumMines++;

                    i_offset = i + 1;
                    j_offset = j + 1;
                    if ((i_offset < heightSize) && (j_offset < widthSize) && (arrMines[i_offset, j_offset] == 99))
                        sumMines++;

                    arrCntMines[i, j] = sumMines;
                }
            }
        }

        private void InitialStateArrCurrentStateGame()
        {
            for (int i = 0; i < heightSize; i++)
            {
                for (int j = 0; j < widthSize; j++)
                {
                    arrCurrentStateGame[i, j] = 1111;
                }
            }
        }

        private void Clear()
        {
            gridField.RowDefinitions.Clear();
            gridField.ColumnDefinitions.Clear();
            gridField.Children.Clear();
        }

        private void GameCompletionCheck()
        {
            bool check = false;

            for (int i = 0; i < heightSize; i++)
            {
                for (int j = 0; j < widthSize; j++)
                {
                    if (arrFlags[i, j] == arrMines[i, j])
                    {
                        check = true;
                    }
                    else
                    {
                        return;
                    }
                }
            }

            if (check)
                MessageBox.Show("Поздравляем! Вы выиграли");
        }

        private void Button_Easy(object sender, RoutedEventArgs e)
        {
            heightSize = 9;
            widthSize = 9;
            mines = 10;
             
            NewGame();
        }

        private void Button_Medium(object sender, RoutedEventArgs e)
        {
            heightSize = 16;
            widthSize = 16;
            mines = 40;

            NewGame();
        }

        private void Button_Expert(object sender, RoutedEventArgs e)
        {
            heightSize = 16;
            widthSize = 30;
            mines = 99;

            NewGame();
        }

        private void Button_Custom(object sender, RoutedEventArgs e)
        {
            CustomSettings customSett = new CustomSettings();
            customSett.Owner = this;
            
            customSett.ShowDialog();
        }
    }
}
