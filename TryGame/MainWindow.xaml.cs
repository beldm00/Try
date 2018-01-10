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
        Ab3d.Reader3ds _myReader3ds;
        //REVIEW: Файл - в конфиг
        string resultsPath = "results.txt";
        Window childWindow = new Window1();
        public MainWindow()
        {
            InitializeComponent();
            SoundManager.getInstance().Play();

            _myReader3ds = new Ab3d.Reader3ds();

            //REVIEW: Название файла - в настройки
            _myReader3ds.ReadFile("N_aperstki.3ds", MyViewport3D);

            _myReader3ds.Animator.GoToFrame(100);

            _myReader3ds.Animator.AutoRepeat = true;
            _myReader3ds.Animator.AnimationDuration = TimeSpan.FromSeconds(5);
            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering); 

        }
        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            _myReader3ds.Animator.DoAnimate();
        }

        //REVIEW: Все клики - в команды во вьюмодель
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
