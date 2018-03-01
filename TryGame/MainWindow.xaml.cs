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
        private ViewModel _VM;
        public MainWindow()
        {
            InitializeComponent();
            _VM = new ViewModel();
            SoundManager.getInstance().Play();
            this.DataContext = _VM;
            //_VM.Initilize(MyViewport3D);

            //CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering); 

        }
        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            //_VM._myReader3ds.Animator.DoAnimate();
        }
        /*
        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            _VM.PlayButton.Execute(sender);
        }*/
        
        /*private void Statistika_Click(object sender, RoutedEventArgs e)
        {
            _VM.Statistika_Click();
        }*/

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SoundManager.getInstance().Close();
            _VM.childWindow.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _VM.Load();
        }
    }
}
