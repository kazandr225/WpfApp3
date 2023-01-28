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
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MN = new MainWindow();

            if (tbNum.Text == MN.anum) //сравниваем введенное число с фактическим
            {
                
                MN.Show();
                this.Close();
                MN.successInp(); //успешная авторизация
            }
            else
            {
                MN.Show();
                this.Close();
                MN.unsuccessInp(); //была допущена ошибка
            }

        }
    }
}
