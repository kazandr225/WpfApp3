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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public static string anum; //сгенерированное число
        public AutorizationPage()
        {
            InitializeComponent();
        }
        public AutorizationPage(int a)
        {
            InitializeComponent();
            spTm.Visibility = Visibility.Visible;
            unsuccessInp();
        }
        

        public void btnAutorization_Click(object sender, RoutedEventArgs e)
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

        public void unsuccessInp() //при входе было допущена ошибка
        {
            
            MessageBox.Show("Введено неверное значение ожидайте 60 секунд", "Ошибка ввода", MessageBoxButton.OK);

            int sec = 60;

            //for (int i = 1; i < 60; i++)
            //{
            //    sec --;
            //    tblSec.Text = sec.ToString();
            //}
            //spTm.Visibility = Visibility.Hidden;

            //for (int i = 0; i < 60; i++) 
            //{ 
            //    if (sec <= 0) 
            //    { 
            //        sec--; tblSec.Text = sec.ToString(); 
            //    } 
            //}
            //MessageBox.Show("Отсчет завершен", "Дада", MessageBoxButton.OK); 
            //spTm.Visibility = Visibility.Hidden;

            //if (sec >= 0)
            //{
            //    sec--;
            //    tblSec.Text = sec.ToString();
            //}

            //else
            //{
            //    MessageBox.Show("Отсчет завершен", "Дада", MessageBoxButton.OK);
            //    spTm.Visibility = Visibility.Hidden;
            //}

            for (int i = 0; i >= 60; i++)
            {
                
                //if (sec >= 0)
                //{
                //    sec--;
                //    tblSec.Text = sec.ToString();
                //}
                sec--;
                tblSec.Text = sec.ToString();

            }
            MessageBox.Show("Отсчет завершен", "Дада", MessageBoxButton.OK);
            spTm.Visibility = Visibility.Hidden;

        }
    }
}
