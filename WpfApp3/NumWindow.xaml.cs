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
using System.Windows.Threading;
using WpfApp3.Classes;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для NumWindow.xaml
    /// </summary>
    public partial class NumWindow : Window
    {
        DispatcherTimer timercode = new DispatcherTimer(); //таймер для введения кода



        public int inputerror = 0; //считаем ошибки
        public NumWindow()
        {
            InitializeComponent();

            //Устанавливаем окно по центру экрана
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;
            this.Top = (screenHeight - this.Height) / 2;
            this.Left = (screenWidth - this.Width) / 2;


            timercode.Interval = new TimeSpan(0, 1, 0); //устанавливаем интеврвал для введения кода
            timercode.Start(); //запускаем таймер
            timercode.Tick += new EventHandler(again);
        }

        public void again(object sender, EventArgs e) //закрывает окно и открывает 2 вариант авторизации
        {
            AutorizationPage AP = new AutorizationPage();

            inputerror++; //считаем ошибку

            if (inputerror == 2) //если пользователь ошибся 2 раза
            {
                inputerror = 0; //сбрасываем значание
                FrameClass.MainFrame.Navigate(new CAPTCHAPage()); //переходим на станицу с капчей
            }
            else
            {
                timercode.Stop(); //Останавливаем таймер
                this.Hide(); //прячем окно
                FrameClass.MainFrame.Navigate(new AutorizationPage(1)); //открываем окно с кодом заново
            }  
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            AutorizationPage AP = new AutorizationPage();

            if (inputerror == 2) //если пользователь ошибся 2 раза
            {
                inputerror = 0; //сбрасываем значание
                FrameClass.MainFrame.Navigate(new CAPTCHAPage()); //переходим на станицу с капчей
                timercode.Stop();
            }

            else 
            {
                if (tbNum.Text == AutorizationPage.anum) //сравниваем введенное число с фактическим
                {
                    AP.successInp(); //успешная авторизация
                    this.Hide();
                }
                else
                {
                    inputerror++; //считаем ошибку
                    this.Hide();
                    FrameClass.MainFrame.Navigate(new AutorizationPage(1)); //загрузка страницы в случае ошибки ввода
                }
            }    
        }
    }
}
