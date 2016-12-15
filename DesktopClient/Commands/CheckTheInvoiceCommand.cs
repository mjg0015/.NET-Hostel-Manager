using System;
using System.Windows.Input;
using DesktopClient.ViewModel;

namespace DesktopClient.Commands
{
    class CheckTheInvoiceCommand : ICommand
    {
        private readonly CheckInManagementViewModel viewModel;

        public CheckTheInvoiceCommand(CheckInManagementViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.CheckTheInvoiceAction();
        }

        public event EventHandler CanExecuteChanged;
    }
}
