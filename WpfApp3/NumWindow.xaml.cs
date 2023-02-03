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
using WpfApp3.Classes;

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для NumWindow.xaml
    /// </summary>
    public partial class NumWindow : Window
    {
        public NumWindow()
        {
            InitializeComponent();

            //Устанавливаем окно по центру экрана
            double screenHeight = SystemParameters.FullPrimaryScreenHeight;
            double screenWidth = SystemParameters.FullPrimaryScreenWidth;
            this.Top = (screenHeight - this.Height) / 2;
            this.Left = (screenWidth - this.Width) / 2;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            AutorizationPage AP = new AutorizationPage();

            if (tbNum.Text == AutorizationPage.anum) //сравниваем введенное число с фактическим
            {

                //MN.Show();
                AP.successInp(); //успешная авторизация
                this.Hide();
                
            }
            else
            {
                //MN.Show();
                //AP.unsuccessInp(); //была допущена ошибка
                this.Hide();
                FrameClass.MainFrame.Navigate(new AutorizationPage(1));

            }

        }
    }
}
