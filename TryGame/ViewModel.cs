using System;
using System.Collections.Generic;
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
using System.Configuration;
using System.IO;

namespace TryGame
{
    class ViewModel
    {
        //public Ab3d.Reader3ds _myReader3ds;

        string resultsPath = ConfigurationSettings.AppSettings["ResultFileName"];
        public Window1 childWindow;

        public void Initilize(Viewport3D MyViewport3D)
        {/*
            _myReader3ds = new Ab3d.Reader3ds();


            _myReader3ds.ReadFile(ConfigurationSettings.AppSettings["3dsFileName"], MyViewport3D);

            _myReader3ds.Animator.GoToFrame(100);

            _myReader3ds.Animator.AutoRepeat = true;
            _myReader3ds.Animator.AnimationDuration = TimeSpan.FromSeconds(5);*/
        }

        public void Load()
        {
            childWindow = new Window1();
        }

        public void PlayButton_Click()
        {
            childWindow.Show();
        }

        public void Statistika_Click()
        {
            string[] results = File.Exists(resultsPath) ? File.ReadAllLines(resultsPath) : new string[0];
            string message = string.Format("Кол-во побед: {0}{1}Кол-во поражений:{2}", results.Where(x => x.Equals("1")).Count(), Environment.NewLine, results.Where(x => x.Equals("0")).Count());
            string caption = "Statistika";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;
            result = System.Windows.Forms.MessageBox.Show(message, caption, buttons);
        }

    }
}
