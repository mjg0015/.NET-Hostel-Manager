using System;
using System.Windows.Input;
using DesktopClient.ViewModel;

namespace DesktopClient.Commands
{
    class CreateNewBedroomCommand:ICommand
    {
        private readonly CheckInManagementViewModel viewModel;

        public CreateNewBedroomCommand(CheckInManagementViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.CreateNewBedroomAction();
        }

        public event EventHandler CanExecuteChanged;
    }
}
