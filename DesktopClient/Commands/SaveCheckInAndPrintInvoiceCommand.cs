using System;
using System.Windows.Input;
using DesktopClient.ViewModel;

namespace DesktopClient.Commands
{
    class SaveCheckInAndPrintInvoiceCommand:ICommand
    {
        private readonly InvoiceViewModel viewModel;

        public SaveCheckInAndPrintInvoiceCommand(InvoiceViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.SaveCheckInAndPrintInvoiceAction();
        }

        public event EventHandler CanExecuteChanged;
    }
}
