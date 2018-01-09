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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TryGame
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string resultsPath = "results.txt";
        Window childWindow = new Window1();
        public MainWindow()
        {
            InitializeComponent();
            SoundManager.getInstance().Play();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            childWindow.Show();
        }

        private void Statistika_Click(object sender, RoutedEventArgs e)
        {
            string[] results = File.Exists(resultsPath) ? File.ReadAllLines(resultsPath) : new string[0];
            string message = string.Format("Кол-во побед: {0}{1}Кол-во поражений:{2}",results.Where(x=>x.Equals("1")).Count(),Environment.NewLine, results.Where(x => x.Equals("0")).Count());
            string caption = "Statistika";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = System.Windows.Forms.MessageBox.Show(message, caption, buttons);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SoundManager.getInstance().Close();
            childWindow.Close();
        }
    }
}
