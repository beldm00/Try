using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TryGame;
using System.Windows.Input;

namespace TryGame
{

    class ViewModel1 : INotifyPropertyChanged
    {
        private ICommand _button1;
        private ICommand _button2;
        private ICommand _button3;

        public ICommand button1
        {
            get { return _button1; }
        }

        public ICommand button2
        {
            get { return _button2; }
        }

        public ICommand button3
        {
            get { return _button3; }
        }

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
            _button1 = new CommandWithParameters(Result_Button_Click);
            _button2 = new CommandWithParameters(Result_Button_Click);
            _button3 = new CommandWithParameters(Result_Button_Click);

            resultText = "Попробуй выбери правильный ответ:";
        }
        public void Result_Button_Click(string value)
        {
            rightAnswer = random.Next(1, 3);
            File.AppendAllLines(resultsPath, new string[] { rightAnswer.ToString().Equals(value) ? "1" : "0" });
            ResultText = rightAnswer.ToString().Equals(value) ? "Поздравляю с победой. Попробуй еще." : "Проиграл. Не унывай. Попробуй еще.";
        }
    }
}

