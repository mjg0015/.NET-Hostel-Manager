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
    public class CheckInManagementViewModel  :INotifyPropertyChanged
    {
        #region Binded Properties
        
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

        private CheckIn currentCheckIn;

        public CheckIn CurrentCheckIn
        {
            get { return currentCheckIn; }
            set
            {
                currentCheckIn = value;
                OnPropertyChanged();
            }
        }

        public string ManagerName { get; }

        #endregion

        #region Service instances

        private IBedroomService bedroomService;
        private ICheckInService checkInService;

        #endregion

        #region Commands properties

        public ICommand SaveCheckIn { get; private set; }
        public ICommand UpdateBedroom { get; private set; }
        public ICommand DeleteBedroom { get; private set; }
        public ICommand CreateNewBedroom { get; private set; }
        public ICommand DeleteCheckIn { get; private set; }

        #endregion

        public CheckInManagementViewModel(UserEventArgs userEventArgs)
        {
            initializeCommands();
            ManagerName = userEventArgs.UserName;
            initializeProperties();
            subscribeEvents();
            canExecuteSaveCheckIn = true;
        }

        #region Events

        private void subscribeEvents()
        {
            Managers.EventManager.SaveNewBedroomButtonPressed += onSaveNewBedroomButtonPressed;
            Managers.EventManager.DeleteBedroomButtonPressed += onDeleteBedroomButtonPressed;
            Managers.EventManager.SaveCheckInButtonPressed += onSaveCheckInButtonPressed;
            Managers.EventManager.DeleteCheckInButtonPressed += onDeleteCheckInButtonPressed;
        }

        private void onDeleteCheckInButtonPressed(object source, CheckInEventArgs eventArgs)
        {
            reloadData();
        }

        private void onSaveCheckInButtonPressed(object source, EventArgs eventArgs)
        {
            reloadData();
        }

        private void onDeleteBedroomButtonPressed(object source, EventArgs eventArgs)
        {
            reloadData();
        }

        private void onSaveNewBedroomButtonPressed(object source, EventArgs eventArgs)
        {
           reloadData();
        }


        #endregion

        #region CanExecute Props

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
        public bool CanExecuteCreateNewBedroom
        {
            get { return canExecuteCreateNewBedroom; }
            private set
            {
                canExecuteCreateNewBedroom = value;
                OnPropertyChanged();
            }
        }

        private bool canExecuteUpdateCheckIn;
        public bool CanExecuteCanUpdateCheckIn
        {
            get { return canExecuteUpdateCheckIn; }
            private set
            {
                canExecuteUpdateCheckIn = value;
                OnPropertyChanged();
            }
        }

        private bool canExecuteDeleteCheckIn;
        public bool CanExecuteDeleteCheckIn
        {
            get { return canExecuteDeleteCheckIn; }
            private set
            {
                canExecuteDeleteCheckIn = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private void initializeCommands()
        {
            SaveCheckIn = new SaveCheckInCommand(this);
            UpdateBedroom = new UpdateBedroomCommand(this);
            DeleteBedroom = new DeleteBedroomCommand(this);
            CreateNewBedroom = new CreateNewBedroomCommand(this);
            DeleteCheckIn = new DeleteCheckInCommand(this);
        }

        private void initializeProperties()
        {
            CheckIn = new CheckIn();
            CheckIn.ArrivingDate = DateTime.Today;
            CheckIn.DepartureDate = DateTime.Today.AddDays(1);
            bedroomService = new BedroomService();
            checkInService = new CheckInService();
            reloadData();
        }

        private async void reloadData()
        {
            AllRoomsList = await bedroomService.GetAllAsync();
            AllCheckInList = await checkInService.GetPendingCheckOutAsync();
            AvailableRoomsList = await bedroomService.GetAvailableAsync();
            AllRoomsList = await bedroomService.GetAllAsync();
            AllCheckInList = await checkInService.GetPendingCheckOutAsync();
        }

        private void createListOfGuests()
        {
            if (currentAvailableBedroom != null)
            {
                GuestList = new List<Guest>();
                for (int i = 1; i <= currentAvailableBedroom.Size; i++)
                {
                    GuestList.Add(new Guest());
                }
                CheckIn.Guests = GuestList;
            }
            else
            {
                GuestList = new List<Guest>();
            }
        }

        private bool IsCheckInOk(CheckIn checkIn)
        {
            bool answer = false;

            if (CurrentAvailableBedroom != null)
                foreach (var guest in GuestList)
                {
                    if (guest.DocumentId != null & guest.Name != null & guest.Surname != null)
                        answer = true;
                    else
                    {
                        return false;
                    }
                }
            return answer;
        }

        #region Actions

        public void UpdateBedroomAction()
        {
            if (CurrentBedroom != null)
                Managers.EventManager.OnUpdateBedroomButtonPressed(this, CurrentBedroom);
        }

        public void DeleteBedroomAction()
        {
            if (CurrentBedroom != null)
                Managers.EventManager.OnDeleteBedroomButtonPressed(this, CurrentBedroom);
        }

        public  void SaveCheckInAction()
        {
            CheckIn.Bedroom = currentAvailableBedroom;
            if (IsCheckInOk(CheckIn))
            {
                Managers.EventManager.OnSaveCheckInButtonPressed(this,CheckIn);
            }
        }

        public void CreateNewBedroomAction()
        {
            Managers.EventManager.OnCreateNewBedroomButtonPressed(this,new EventArgs());
        }

        public void DeleteCheckInAction()
        {
            if(CurrentCheckIn!=null)
            Managers.EventManager.OnDeleteCheckInButtonPressed(this,CurrentCheckIn);
        }

        #endregion

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
