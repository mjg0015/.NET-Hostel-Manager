using DesktopClient.ViewModel;
using System;
using System.Windows.Input;

namespace DesktopClient.Commands
{
    class UpdateRoomCommand :ICommand
    {
        private readonly CheckInManagementViewModel viewModel;

        public UpdateRoomCommand(CheckInManagementViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.UpdateRoomAction();
        }

        public event EventHandler CanExecuteChanged;
    }
}
