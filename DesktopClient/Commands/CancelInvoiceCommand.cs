using System;
using System.Windows.Input;
using DesktopClient.ViewModel;

namespace DesktopClient.Commands
{
    class CancelInvoiceCommand:ICommand
    {
        private readonly InvoiceViewModel viewModel;

        public CancelInvoiceCommand(InvoiceViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.CancelInvoiceAction();
        }

        public event EventHandler CanExecuteChanged;
    }
}
