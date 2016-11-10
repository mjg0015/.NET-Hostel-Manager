﻿using System;
using System.Windows.Input;
using DesktopClient.ViewModel;

namespace DesktopClient.Commands
{
    class DeleteCheckInCommand : ICommand
    {
        private readonly CheckInManagementViewModel viewModel;

        public DeleteCheckInCommand(CheckInManagementViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            viewModel.DeleteCheckInAction();
        }

        public event EventHandler CanExecuteChanged;
    }
}
