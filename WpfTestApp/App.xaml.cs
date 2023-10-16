using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfTestApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Mutex? mutex;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Check for existing instance
            string mutexName = "MyApp.WpfTestApp";
            bool createdNew;
            mutex = new Mutex(true, mutexName, out createdNew);
            // If there is an existing instance, shut down this one
            if (!createdNew) { Shutdown(); }

        }
    }
}
