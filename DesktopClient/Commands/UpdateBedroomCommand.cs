using DesktopClient.ViewModel;
using System;
using System.Windows.Input;

namespace DesktopClient.Commands
{
    class UpdateBedroomCommand :ICommand
    {
        private readonly CheckInManagementViewModel viewModel;

        public UpdateBedroomCommand(CheckInManagementViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.UpdateBedroomAction();
        }

        public event EventHandler CanExecuteChanged;
    }
}
