using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DesktopClient.Commands;
using DesktopClient.Model;
using DesktopClient.Service;


namespace DesktopClient.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public LoginViewModel()
        {
            User = new User();
            Login = new LoginCommand(this);
        }

        public User User { get; }

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

        public void LoginAction()
        {
            IAuthenticationService authService = new AuthenticationService();
            User user = authService.DoLogin(User.Name, User.Password);

            if (user != null)
            {
                Managers.EventManager.OnUserLoggedIn(this, User.Name);
            }
            else
            {

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
