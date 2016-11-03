using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopClient.EventArgsExtenctions;
using DesktopClient.View;
using Domain.Model;

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
            CheckInManagementWindow checkInManagementWindow = new CheckInManagementWindow();
            checkInManagementWindow.Show();
            loginWindow.Close();
        }
    }
}