using System;
using System.Windows.Input;
using DesktopClient.ViewModel;

namespace DesktopClient.Commands
{
    class SaveBedroomCommand:ICommand
    {
        private readonly BedroomEditorViewModel viewModel;

        public SaveBedroomCommand(BedroomEditorViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.SaveBedroomAction();
        }

        public event EventHandler CanExecuteChanged;
    }
}
