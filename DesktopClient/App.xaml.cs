using System.Windows;
using DesktopClient.Managers;
using DesktopClient.View;

namespace DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            LoginWindow startWindow = new LoginWindow();
            new ViewManager(startWindow);
        }
    }
}
