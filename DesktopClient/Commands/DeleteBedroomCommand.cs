using System;
using System.Windows.Input;
using DesktopClient.ViewModel;

namespace DesktopClient.Commands
{
    class DeleteBedroomCommand :ICommand
    {
        private readonly CheckInManagementViewModel viewModel;

        public DeleteBedroomCommand(CheckInManagementViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.DeleteBedroomAction();
        }

        public event EventHandler CanExecuteChanged;
    }
}
