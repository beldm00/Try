using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TryGame
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() : base()
        {

            DispatcherUnhandledException += App_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Exception, sorry: Details in the exceptions.errorlog", "Exception", MessageBoxButton.OK);
            if (result == MessageBoxResult.OK)
            {
                File.AppendAllText("exceptions.errorlog", string.Format("{0} ({1}){2}", e.ToString(), e.ExceptionObject.ToString(), Environment.NewLine));
                Environment.Exit(1);
            }
        }

        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Exception, sorry:" + e.Exception.Message, "Exception", MessageBoxButton.OK);
            if (result == MessageBoxResult.OK)
            {
                File.AppendAllText("exceptions.errorlog", string.Format("{0}-{1}-{2}-{3}-{4}-{5}{6}", e.Exception.Message, e.Dispatcher.ToString(), e.ToString(), e.Exception.Source.ToString(), e.Exception.TargetSite.Name, e.Exception.TargetSite.ToString(), Environment.NewLine));
                e.Handled = true;
                Environment.Exit(1);
            }
        }
    }

}
