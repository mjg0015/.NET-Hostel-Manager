using System;
using System.Windows.Input;
using DesktopClient.ViewModel;

namespace DesktopClient.Commands
{
    class SaveCheckInCommand : ICommand
    {
        private readonly CheckInManagementViewModel viewModel;

        public SaveCheckInCommand(CheckInManagementViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.SaveCheckInAction();
        }

        public event EventHandler CanExecuteChanged;
    }
}
