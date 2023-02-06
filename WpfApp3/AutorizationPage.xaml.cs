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
using System.Windows.Threading;
using WpfApp3.Classes;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer(); //таймер

        public static string anum; //сгенерированное число

        public int sec = 3; //задаем требуемое для ожидания время

        public AutorizationPage()
        {
            InitializeComponent();
        }
        public AutorizationPage(int a)
        {
            InitializeComponent();
            spTm.Visibility = Visibility.Visible;
            btnAutorization.IsEnabled = false;

            timer.Interval = new TimeSpan(0, 0, 1); //устанавливаем интервал в 1 секунду
            timer.Start(); //запускаем таймер
            timer.Tick += new EventHandler(unsuccessInp); //по окончанию таймера, метод будет запускаться, обновляя число
        }

        public void btnAutorization_Click(object sender, RoutedEventArgs e) //собысия на клик по кнопке авторизации 
        {
            NumWindow NW = new NumWindow();

            string login = "Иван"; //задаем логин и пароль
            string password = "1234";

            if (login == tbLogin.Text && password == tbPassword.Text) //условие на проверку введенных значений
            {
                Random rnd = new Random();
                int num = rnd.Next(10000, 99999); // случайное 5-ое число

                MessageBox.Show(num.ToString(), "Запомните одноразовый код", MessageBoxButton.OK); //вывод сообщения со сгенерированным значением
                anum = num.ToString();
                NW.Show(); //вызов окна с вводом кода

            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка ввода", MessageBoxButton.OK); //ошибка при вводе
            }
        }

        public void successInp() //успешный вход
        {
            MessageBox.Show("Вы авторизировались", "Поздравляем!", MessageBoxButton.OK);
        }

        public void unsuccessInp(object sender, EventArgs e) //при входе было допущена ошибка
        {
            

            if (sec != 0)
            {
                tblSec.Text = sec.ToString();
                sec--;
            }

            else 
            {
                timer.Stop(); //останавливаем работу таймера
                FrameClass.MainFrame.Navigate(new AutorizationPage()); //открываем страницу без таймера и с активированной кнопкой
                MessageBox.Show("Отсчет закончен", "Повторите ввод!", MessageBoxButton.OK);
            }
        }
    }
}
