using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TryGame
{
    class ViewModel1 : INotifyPropertyChanged
    {
        private Random random = new Random();
        private int rightAnswer;
        string resultsPath = ConfigurationSettings.AppSettings["ResultFileName"];
        private string resultText;
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string ResultText {
            get
            {
                return resultText;
            }
            set
            {
                resultText = value;

                NotifyPropertyChanged();
            }
        }

        public ViewModel1()
        {
            resultText = "Попробуй выбери правильный ответ:";
        }
        public void Result_Button_Click(int value)
        {
            rightAnswer = random.Next(0, 3);
            File.AppendAllLines(resultsPath, new string[] { rightAnswer == 2 ? "1" : "0" });
            ResultText = rightAnswer == 2 ? "Поздравляю с победой. Попробуй еще." : "Проиграл. Не унывай. Попробуй еще.";
        }
    }
}
