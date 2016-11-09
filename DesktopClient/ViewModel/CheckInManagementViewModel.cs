using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DesktopClient.Commands;
using DesktopClient.EventArgsExtenctions;
using DesktopClient.Model;
using DesktopClient.Service;

namespace DesktopClient.ViewModel
{
    class CheckInManagementViewModel  :INotifyPropertyChanged
    {
        private List<Guest> guestList;
        public List<Guest> GuestList
        {
            get { return guestList; }
            set
            {
                guestList = value;
                OnPropertyChanged();
                
            }
        }

        private CheckIn checkIn;
        public CheckIn CheckIn
        {
            get { return checkIn; }
            set
            {
                checkIn = value;
                OnPropertyChanged();
            }
        }
 
        private List<CheckIn> allCheckInList;
        public List<CheckIn> AllCheckInList
        {
            get { return allCheckInList; }
            set
            {
                allCheckInList = value;
                OnPropertyChanged();
            }
        }

        private List<Bedroom> availableRoomsList;
        public List<Bedroom> AvailableRoomsList
        {
            get { return availableRoomsList; }
            set
            {
                availableRoomsList = value;
                OnPropertyChanged();
            }
        }

        private List<Bedroom> allRoomsList;
        public List<Bedroom> AllRoomsList
        {
            get { return allRoomsList; }
            set
            {
                allRoomsList = value;
                OnPropertyChanged();
            }
        }

        public string ManagerName { get; }

        private Bedroom currentBedroom ;
        public Bedroom CurrentBedroom
        {
            get { return currentBedroom; }
             set
            {
                currentBedroom = value;
                createListOfGuests();
                OnPropertyChanged();
            }
        }

        private Bedroom currentRoom;
        public Bedroom CurrentRoom
        {
            get
            {
                return currentRoom;
            }
            set
            {
                currentRoom = value;
                OnPropertyChanged();
            }
        }

        private IBedroomService bedroomService;
        private ICheckInService checkInService;

        public CheckInManagementViewModel(UserEventArgs userEventArgs)
        {
            SaveCheckIn=new SaveCheckInCommand(this);
            //UpdateRoom = new UpdateRoomCommand(this);
            //DeleteRoom = new DeleteRoomCommand(this);
            ManagerName = userEventArgs.UserName;
            initializeProperties();
            canExecuteSaveCheckIn = true;
        }

       

        private async void initializeProperties()
        {
            CheckIn = new CheckIn();
            CheckIn.ArrivingDate = DateTime.Today;
            CheckIn.DepartureDate = DateTime.Today.AddDays(1);
            
            bedroomService = new BedroomService();
            AvailableRoomsList = await bedroomService.GetAvailableAsync();
            AllRoomsList = await bedroomService.GetAllAsync();
            
         }

        private void createListOfGuests()
        {
            GuestList = new List<Guest>();
            for (int i = 1; i <= currentBedroom.Size; i++)
            {
                GuestList.Add(new Guest());
            }
            CheckIn.Guests = GuestList;
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

        private bool canExecuteUpdateRoom;

        public bool CanExecuteUpdateRoom
        {
            get { return canExecuteUpdateRoom; }
            private set
            {
                canExecuteUpdateRoom = value;
                OnPropertyChanged();
            }
        }
        private bool canExecuteDeleteRoom;

        public bool CanExecuteDeleteRoom
        {
            get { return canExecuteDeleteRoom; }
            private set
            {
                canExecuteDeleteRoom = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCheckIn { get; private set; }
        public ICommand UpdateRoom { get; private set; }
        public ICommand DeleteRoom { get; private set; }

        public void UpdateRoomAction()
        {
            
            var a = 0;
        }
        public void DeleteRoomAction() { }

        public async void SaveCheckInAction()
        {
            //CheckIn.Bedroom = CurrentBedroom;
            //if (IsCheckInOk)
            //{
            //   ;
            //    Managers.EventManager...
            //    reload every Property.
            //}
            
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
