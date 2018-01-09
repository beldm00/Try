using System;
using System.Collections.Generic;
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
        string resultsPath = "results.txt";






        public Window1()
        {
            InitializeComponent();
            random = new Random();
            rightAnswer = random.Next(0, 3);



        }


        private Random random;
        private int rightAnswer;
        private bool isClose = false;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            File.AppendAllLines(resultsPath, new string[] { rightAnswer == 0 ? "1" : "0" });
            textBlock.Text = rightAnswer == 0 ? "Поздравляю с победой. Попробуй еще." : "Проиграл. Не унывай. Попробуй еще.";
            rightAnswer = random.Next(0, 3);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            File.AppendAllLines(resultsPath, new string[] { rightAnswer == 1 ? "1" : "0" });
            textBlock.Text = rightAnswer == 1 ? "Поздравляю с победой. Попробуй еще." : "Проиграл. Не унывай. Попробуй еще.";
            rightAnswer = random.Next(0, 3);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isClose)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        public void Close()
        {
            isClose = true;
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            File.AppendAllLines(resultsPath, new string[] { rightAnswer == 2 ? "1" : "0" });
            textBlock.Text = rightAnswer == 2 ? "Поздравляю с победой. Попробуй еще." : "Проиграл. Не унывай. Попробуй еще.";
            rightAnswer = random.Next(0, 3);
        }
    }
}
