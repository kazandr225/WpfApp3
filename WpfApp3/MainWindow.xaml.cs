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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string anum; //сгенерированное число
        public MainWindow()
        {
            InitializeComponent();
        }

        public void btnAutorization_Click(object sender, RoutedEventArgs e)
        {
            NumWindow NW = new NumWindow();
            
            string login = "Иван"; //задаем логин и пароль
            string password = "1234";

            if (login == tbLogin.Text && password== tbPassword.Text) //условие на проверку введенных значений
            {
                Random rnd = new Random();
                int num = rnd.Next(10000, 99999); // случайное 5-ое число

                MessageBox.Show(num.ToString(), "Запомните одноразовый код", MessageBoxButton.OK); //вывод сообщения со сгенерированным значением
                anum = num.ToString();

                this.Hide();
                NW.Show();

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
        }
    }
}
