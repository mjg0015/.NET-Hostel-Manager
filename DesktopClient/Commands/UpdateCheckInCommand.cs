using System;
using System.Windows.Input;
using DesktopClient.ViewModel;

namespace DesktopClient.Commands
{
    class UpdateCheckInCommand :ICommand
    {
        private readonly CheckInManagementViewModel viewModel;

        public UpdateCheckInCommand(CheckInManagementViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.UpdateCheckInAction();
        }

        public event EventHandler CanExecuteChanged;
    }
}
