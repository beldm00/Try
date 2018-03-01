using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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

namespace TryGame
{






    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private ViewModel1 _VM1;
        
        public Window1()
        {
            InitializeComponent();
            _VM1 = new ViewModel1();
            this.DataContext = _VM1;
        }

        private bool isClose = false;
        /*
        //REVIEW: Все клики - в команды во вьюмодель
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _VM1.Result_Button_Click(1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _VM1.Result_Button_Click(2);
        }*/

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isClose)
            {
                this.Hide();
                e.Cancel = true;
            }
        }
        /*
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _VM1.Result_Button_Click(3);
        }*/
    }
}
