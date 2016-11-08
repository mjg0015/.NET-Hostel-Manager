using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DesktopClient.Commands;
using DesktopClient.EventArgsExtenctions;
using DesktopClient.Model;
using DesktopClient.Service;

namespace DesktopClient.ViewModel
{
    class CheckInManagementViewModel  :INotifyPropertyChanged
    {
        public Guest Guest { get; }
        public CheckIn CheckIn { get; }
        public List<Bedroom> AvailableRoomsList { get; }
        public List<Bedroom> AllRoomsList { get; }
        public List<CheckIn> AllCheckInList { get; }  
        public string ManagerName { get; }

        public CheckInManagementViewModel(UserEventArgs userEventArgs)
        {
            CheckIn= new CheckIn();
            Guest= new Guest();
            SaveCheckIn=new SaveCheckInCommand(this);
            ManagerName = userEventArgs.UserName;
            //Bedroom service usage example:
            IBedroomService bedroomServ = new BedroomService();
            AvailableRoomsList = bedroomServ.GetAvailable();
            AllRoomsList = bedroomServ.GetAll();
         
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
