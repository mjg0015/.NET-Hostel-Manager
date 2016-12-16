using System.Text.RegularExpressions;
using System.Windows;
using DesktopClient.EventArgsExtenctions;
using DesktopClient.Managers;
using DesktopClient.View;
using System;

namespace DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Only for development purposes!
            System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            base.OnStartup(e);
            LoginWindow startWindow = new LoginWindow();
            new ViewManager(startWindow); 
        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("MyHandler caught : " + e.Message);
            Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);

            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\log.txt", true);
            file.WriteLine(e.Message);

            file.Close();
        }
    }
}
