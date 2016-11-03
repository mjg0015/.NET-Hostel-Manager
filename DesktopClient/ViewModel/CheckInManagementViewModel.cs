using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DesktopClient.Commands;
using Domain.Model;

namespace DesktopClient.ViewModel
{
    class CheckInManagementViewModel  :INotifyPropertyChanged
    {
        public Guest Guest { get; }
        public CheckIn CheckIn { get; } 
        public CheckInManagementViewModel()
        {
                 CheckIn= new CheckIn();
                 Guest= new Guest();
            SaveCheckIn=new SaveCheckInCommand(this);
            canExecuteSaveCheckIn = true;
        }
        private bool canExecuteSaveCheckIn;

        public bool CanExecuteSaveCheckIn
        {
            get { return canExecuteSaveCheckIn; }
            private set
            {
                canExecuteSaveCheckIn = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCheckIn { get; private set; }

        public void SaveCheckInAction()
        {
            throw new NotImplementedException();
        }
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
