using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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

        private Bedroom currentAvailableBedroom ;
        public Bedroom CurrentAvailableBedroom
        {
            get { return currentAvailableBedroom; }
             set
            {
                currentAvailableBedroom = value;
                createListOfGuests();
                OnPropertyChanged();
            }
        }

        private Bedroom currentBedroom;
        public Bedroom CurrentBedroom
        {
            get
            {
                return currentBedroom;
            }
            set
            {
                currentBedroom = value;
                OnPropertyChanged();
            }
        }

        private IBedroomService bedroomService;
        private ICheckInService checkInService;

        public CheckInManagementViewModel(UserEventArgs userEventArgs)
        {
            SaveCheckIn = new SaveCheckInCommand(this);
            UpdateBedroom = new UpdateBedroomCommand(this);
            DeleteBedroom = new DeleteBedroomCommand(this);
            CreateNewBedroom = new CreateNewBedroomCommand(this);
            ManagerName = userEventArgs.UserName;
            initializeProperties();
            Managers.EventManager.SaveNewBedroomButtonPressed+= onSaveNewBedroomButtonPressed;
            canExecuteSaveCheckIn = true;
        }

        private void onSaveNewBedroomButtonPressed(object source, EventArgs eventArgs)
        {
           reloadData();
        }

        private async void initializeProperties()
        {
            CheckIn = new CheckIn();
            CheckIn.ArrivingDate = DateTime.Today;
            CheckIn.DepartureDate = DateTime.Today.AddDays(1);
            bedroomService = new BedroomService();
            checkInService =new CheckInService();
           reloadData();
        }

        private async void reloadData()
        {
            AvailableRoomsList = await bedroomService.GetAvailableAsync();
            AllRoomsList = await bedroomService.GetAllAsync();
            AllCheckInList = await checkInService.GetPendingCheckOutAsync();
        }

        private void createListOfGuests()
        {
            GuestList = new List<Guest>();
            for (int i = 1; i <= currentAvailableBedroom.Size; i++)
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

        private bool canExecuteUpdateBedroom;
        public bool CanExecuteUpdateBedroom
        {
            get { return canExecuteUpdateBedroom; }
            private set
            {
                canExecuteUpdateBedroom = value;
                OnPropertyChanged();
            }
        }

        private bool canExecuteDeleteBedroom;
        public bool CanExecuteDelete
        {
            get { return canExecuteDeleteBedroom; }
            private set
            {
                canExecuteDeleteBedroom = value;
                OnPropertyChanged();
            }
        }

        private bool canExecuteCreateNewBedroom;
        public bool CanExecuteCanCreateNewBedroom
        {
            get { return canExecuteCreateNewBedroom; }
            private set
            {
                canExecuteCreateNewBedroom = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCheckIn { get; private set; }
        public ICommand UpdateBedroom { get; private set; }
        public ICommand DeleteBedroom { get; private set; }
        public ICommand CreateNewBedroom { get; private set; }

        public void UpdateBedroomAction()
        {
           Managers.EventManager.OnUpdateBedroomButtonPressed(this,CurrentBedroom);
            
        }

        public void DeleteBedroomAction()
        {
            Managers.EventManager.OnDeleteBedroomButtonPressed(this,CurrentBedroom);
        }

        public  void SaveCheckInAction()
        {
            CheckIn.Bedroom = currentAvailableBedroom;
            if (IsCheckInOk(CheckIn))
            {
                Managers.EventManager.OnSaveCheckInButtonPressed(this,CheckIn);
            }

        }

        private bool IsCheckInOk(CheckIn checkIn)
        {
            return true;//Need to be implement!
        }

        public void CreateNewBedroomAction()
        {
            Managers.EventManager.OnCreateNewBedroomButtonPressed(this,new EventArgs());
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
