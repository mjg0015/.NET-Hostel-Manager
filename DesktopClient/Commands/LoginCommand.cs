using DesktopClient.ViewModel;
using System;
using System.Windows.Input;

namespace DesktopClient.Commands
{
     class LoginCommand : ICommand
    {
        private readonly LoginViewModel viewModel;

        public LoginCommand(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.LoginAction();
        }

        public event EventHandler CanExecuteChanged;
    }
}
