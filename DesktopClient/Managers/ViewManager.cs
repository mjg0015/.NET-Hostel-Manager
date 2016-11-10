using System;
using System.Linq;
using System.Windows;
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
            Managers.EventManager.SaveCheckInButtonPressed += onSaveCheckInButtonPressed;
            Managers.EventManager.SaveNewBedroomButtonPressed+= onSaveNewBedroomButtonPressed;
            Managers.EventManager.CreateNewBedroomButtonPressed += onCreateNewBedroomButtonPressed;  
            Managers.EventManager.DeleteBedroomButtonPressed += onDeleteBedroomButtonPressed;
            Managers.EventManager.UpdateBedroomButtonPressed += onUpdateBedroomButtonPressed;
        }

        private void onDeleteBedroomButtonPressed(object source, BedroomEventArgs eventArgs)
        {
            
        }

        private void onUpdateBedroomButtonPressed(object source, BedroomEventArgs eventArgs)
        {
            
        }

        private void onSaveCheckInButtonPressed(object source,CheckInEventArgs eventArgs)
        {
            
        }

        private void onSaveNewBedroomButtonPressed(object source, BedroomEventArgs eventArgs)
        {
            foreach (Window window in Application.Current.Windows.Cast<Window>().Where(window => window.IsActive))
            {
                window.Close();
            }
           // throw new NotImplementedException();
        }

        private void onCreateNewBedroomButtonPressed(object source,EventArgs eventArgs)
        {
            new BedroomEditorWindow().Show();
        }
        
        private void onUserLoggedIn(object source, UserEventArgs eventArgs)
        {
            new CheckInManagementWindow(eventArgs).Show(); 
            loginWindow.Close();
        }
    }
}