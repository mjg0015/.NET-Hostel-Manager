using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DesktopClient.AuthenticationService;
using DesktopClient.Commands;
using DomainModel.DataContracts;


namespace DesktopClient.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
            User = new UserDto();
            Login = new LoginCommand(this);
        }

        public UserDto User { get; }

        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }

        private string userPassword ;
        public string UserPassword
        {
            get { return userPassword; }
            set
            {
                userPassword = value;
                OnPropertyChanged();
            }
        }


        private bool canExecuteLogin;

        public bool CanExecuteLogin
        {
            get { return canExecuteLogin; }
            private set
            {
                canExecuteLogin = value;
                OnPropertyChanged();
            }
        }

        public ICommand Login { get; private set; }

        public async void LoginAction()
        {

            IAuthenticationService authService = new AuthenticationServiceClient();
            UserDto user = await authService.DoLoginAsync(User.Name, userPassword);
            if (user != null)
            {
                Managers.EventManager.OnUserLoggedIn(this, User.Name);
            }
            else
            {
                ErrorMessage = "Invalid User name or Password! Please, reenter your credentials.";
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
