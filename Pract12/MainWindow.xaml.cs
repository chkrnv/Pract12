using System;
using System.Windows;
using System.Windows.Threading;

namespace Pract12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        DispatcherTimer timer;

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.IsEnabled = true;
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            time.Text = d.ToString("HH:mm:ss");
            date.Text = d.ToString("dddd dd.MM.yyyy");
        }

        public void Выход_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void Очистить_Click(object sender, RoutedEventArgs e)
        {
            inputFirstValue.Clear();
            inputSecondValue.Clear();
            inputValue.Clear();
            result1.Clear();
            result2.Clear();
            result3.Clear();
            result4.Clear();
        }

        public void О_Программе_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Реализовать расчет задачи: Даны длины ребер a, b, c прямоугольного параллелепипеда." +
                "Найти его объем V =a·b·c и площадь поверхности S = 2·(a·b + b·c + a·c)." +
                "Дано двузначное число.Найти сумму и произведение его цифр.");
        }

        private void Рассчитать1_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                uint firstValue = UInt32.Parse(inputFirstValue.Text);
                uint secondValue = UInt32.Parse(inputSecondValue.Text);
                uint thirdValue = UInt32.Parse(inputThirdValue.Text);

                uint volume = firstValue * secondValue * thirdValue;
                result1.Text = volume.ToString();

                uint square = 2 * ((firstValue * secondValue) + (secondValue * thirdValue) + (firstValue * thirdValue));
                result2.Text = square.ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Данные введены неверно");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
        private void Рассчитать2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uint number1 = UInt32.Parse(inputValue.Text.Substring(0, 1));
                uint number2 = UInt32.Parse(inputValue.Text.Substring(1, 1));
                uint amount = number1 + number2;
                uint multiplication = number1 * number2;

                result3.Text = amount.ToString();
                result4.Text = multiplication.ToString();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Данные введены неверно");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
