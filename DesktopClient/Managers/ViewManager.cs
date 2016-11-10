using System;
using System.Linq;
using System.Windows;
using DesktopClient.EventArgsExtenctions;
using DesktopClient.Service;
using DesktopClient.View;

namespace DesktopClient.Managers
{
    internal class ViewManager
    {
        private LoginWindow loginWindow;
        private CheckInService checkInService;
        private BedroomService bedroomService;
        private CheckInManagementWindow checkInManagementWindow;

        public ViewManager(LoginWindow loginWindow)
        {
            this.loginWindow = loginWindow;
            loginWindow.Show();
            checkInService= new CheckInService();
            bedroomService= new BedroomService();
            Managers.EventManager.UserLoggedIn += onUserLoggedIn;
            Managers.EventManager.SaveCheckInButtonPressed += onSaveCheckInButtonPressed;
            Managers.EventManager.SaveNewBedroomButtonPressed+= onSaveNewBedroomButtonPressed;
            Managers.EventManager.CreateNewBedroomButtonPressed += onCreateNewBedroomButtonPressed;  
            Managers.EventManager.DeleteBedroomButtonPressed += onDeleteBedroomButtonPressed;
            Managers.EventManager.UpdateBedroomButtonPressed += onUpdateBedroomButtonPressed;
        }

        private async void onDeleteBedroomButtonPressed(object source, BedroomEventArgs eventArgs)
        {
            await bedroomService.RemoveAsync(eventArgs.Bedroom);
        }

        private async void onUpdateBedroomButtonPressed(object source, BedroomEventArgs eventArgs)
        {
            new BedroomEditorWindow(eventArgs).Show();
        }

        private async void onSaveCheckInButtonPressed(object source,CheckInEventArgs eventArgs)
        {
           await checkInService.CreateAsync(eventArgs.CheckIn);
        }

        private async void onSaveNewBedroomButtonPressed(object source, BedroomEventArgs eventArgs)
        {
            await bedroomService.CreateOrUpdateAsync(eventArgs.Bedroom);
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
            checkInManagementWindow =new CheckInManagementWindow(eventArgs); 
            checkInManagementWindow.Show();
            loginWindow.Close();
        }
    }
}