using DesktopClient.EventArgsExtenctions;
using DesktopClient.View;

namespace DesktopClient.Managers
{
    internal class ViewManager
    {
        private LoginWindow loginWindow;

        public ViewManager(LoginWindow loginWindow)
        {
            this.loginWindow = loginWindow;
            loginWindow.Show();
            Managers.EventManager.UserLoggedIn += onUserLoggedIn;
        }

        private void onUserLoggedIn(object source, UserEventArgs eventArgs)
        {
            CheckInManagementWindow checkInManagementWindow = new CheckInManagementWindow(eventArgs);
            checkInManagementWindow.Show();
            loginWindow.Close();
        }
    }
}