using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DesktopClient.Adapters;
using DesktopClient.BedroomService;
using DesktopClient.CheckInService;
using DesktopClient.Commands;
using DesktopClient.EventArgsExtenctions;
using DomainModel.DataContracts;

namespace DesktopClient.ViewModel
{
    public class CheckInManagementViewModel  :INotifyPropertyChanged
    {
        #region Binded Properties
        
        private List<GuestDto> guestList;
        public List<GuestDto> GuestList
        {
            get { return guestList; }
            set
            {
                guestList = value;
                OnPropertyChanged();
                
            }
        }

        private CheckInDtoAdapter checkIn;
        public CheckInDtoAdapter CheckIn
        {
            get { return checkIn; }
            set
            {
                checkIn = value;
                OnPropertyChanged();
            }
        }
 
        private List<CheckInDtoAdapter> allCheckInList;
        public List<CheckInDtoAdapter> AllCheckInList
        {
            get { return allCheckInList; }
            set
            {
                allCheckInList = value;
                OnPropertyChanged();
            }
        }

        private List<BedroomDtoAdapter> availableRoomsList;
        public List<BedroomDtoAdapter> AvailableRoomsList
        {
            get { return availableRoomsList; }
            set
            {
               
                    availableRoomsList =value;
               
     
                OnPropertyChanged();
            }
        }

        private List<BedroomDtoAdapter> allRoomsList;
        public List<BedroomDtoAdapter> AllRoomsList
        {
            get { return allRoomsList; }
            set
            {
                allRoomsList = value;
                OnPropertyChanged();
            }
        }

        private BedroomDtoAdapter currentAvailableBedroom ;
        public BedroomDtoAdapter CurrentAvailableBedroom
        {
            get { return currentAvailableBedroom; }
             set
            {
                currentAvailableBedroom = value;
                createListOfGuests();
                OnPropertyChanged();
            }
        }

        private BedroomDtoAdapter currentBedroom;
        public BedroomDtoAdapter CurrentBedroom
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

        private CheckInDtoAdapter currentCheckIn;
        public CheckInDtoAdapter CurrentCheckIn
        {
            get { return currentCheckIn; }
            set
            {
                currentCheckIn = value;
                OnPropertyChanged();
            }
        }

        private List<CheckInDtoAdapter> historyCheckInList;
        public List<CheckInDtoAdapter> HistoryCheckInList
        {
            get { return historyCheckInList; }
            set
            {
                historyCheckInList = value;
                OnPropertyChanged();
            }
        }

        private DateTime lowerBound;

        public DateTime LowerBound
        {
            get { return lowerBound; }
            set
            {
                lowerBound = value;
                reloadHistoryCheckins(lowerBound, upperBound);
                OnPropertyChanged();
               
            }
        }

        private DateTime upperBound;

        public DateTime UpperBound
        {
            get
            {
                return upperBound;
            }
            set
            {
                upperBound = value;
                reloadHistoryCheckins(lowerBound, upperBound);
                OnPropertyChanged();
                
            }
        }

        private bool useDateFilter;

        public bool UseDateFilter
        {
            get { return useDateFilter; }
            set
            {
                useDateFilter = value;
                reloadHistoryCheckins(lowerBound,upperBound);
                OnPropertyChanged();
            }
        }

        private double income;

        public double Income
        {
            get
            {
                return income;
            }
            set
            {
                income = value;
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

        public ICommand CheckTheInvoice { get; private set; }
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
            canExecuteCheckTheInvoice = true;
        }

        #region Events

        private void subscribeEvents()
        {
            Managers.EventManager.SaveNewBedroomButtonPressed += onSaveNewBedroomButtonPressed;
            Managers.EventManager.DeleteBedroomButtonPressed += onDeleteBedroomButtonPressed;
            Managers.EventManager.SaveCheckInAndPrintInvoiceButtonPressed += onSaveCheckInAndPrintInvoiceButtonPressed;
            Managers.EventManager.DeleteCheckInButtonPressed += onDeleteCheckInButtonPressed;
        }

        private void onDeleteCheckInButtonPressed(object source, CheckInEventArgs eventArgs)
        {
            reloadData();
        }

        private void onSaveCheckInAndPrintInvoiceButtonPressed(object source, EventArgs eventArgs)
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

        private bool canExecuteCheckTheInvoice;

        public bool CanExecuteCheckTheInvoice
        {
            get { return canExecuteCheckTheInvoice; }
            private set
            {
                canExecuteCheckTheInvoice = value;
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
            CheckTheInvoice = new CheckTheInvoiceCommand(this);
            UpdateBedroom = new UpdateBedroomCommand(this);
            DeleteBedroom = new DeleteBedroomCommand(this);
            CreateNewBedroom = new CreateNewBedroomCommand(this);
            DeleteCheckIn = new DeleteCheckInCommand(this);
        }

        private void initializeProperties()
        {
            CheckIn = new CheckInDtoAdapter();
            CheckIn.ArrivingDate = DateTime.Today;
            CheckIn.DepartureDate = DateTime.Today.AddDays(1);
            lowerBound = upperBound =DateTime.Today;
            bedroomService = new BedroomServiceClient();
            checkInService = new CheckInServiceClient();
            UseDateFilter = false;
            reloadData();
        }

        private List<BedroomDtoAdapter> toBedroomDtoAdapterList(BedroomDto[] bedrooms)
        {
            List<BedroomDtoAdapter> returnList= new List<BedroomDtoAdapter>();
            foreach (var bedroom in bedrooms)
            {
                returnList.Add(new BedroomDtoAdapter(bedroom));
            }
            return returnList;
        }
        private List<CheckInDtoAdapter> toCheckInAdapterList(CheckInDto[] checkIns)
        {
            List<CheckInDtoAdapter> returnList = new List<CheckInDtoAdapter>();
            foreach (var checkIn in checkIns)
            {
                returnList.Add(new CheckInDtoAdapter(checkIn));
            }
            return returnList;
        }

        private async void reloadHistoryCheckins(DateTime lowerBound, DateTime upperBound)
        {

            if(useDateFilter)
            HistoryCheckInList =
                await
                    checkInService.GetBetweenDatesAsync(lowerBound, upperBound)
                        .ContinueWith(antecendent => toCheckInAdapterList(antecendent.Result));
            else
            {
                HistoryCheckInList =
                await
                    checkInService.GetAllAsync()
                        .ContinueWith(antecendent => toCheckInAdapterList(antecendent.Result));
            }
            Income = 0;
            foreach (var checkIn in HistoryCheckInList)
            {
                Income += checkIn.Price;
            }

        }
        

        private async void reloadData()
        {
            reloadHistoryCheckins(lowerBound,upperBound);
            AllRoomsList = (await bedroomService.GetAllAsync().ContinueWith(antecendent => toBedroomDtoAdapterList(antecendent.Result)));
            AllCheckInList = (await checkInService.GetPendingCheckOutAsync().ContinueWith(antecendent => toCheckInAdapterList(antecendent.Result)));
            AvailableRoomsList = (await bedroomService.GetAvailableAsync().ContinueWith(antecendent => toBedroomDtoAdapterList(antecendent.Result)));
            AllRoomsList = (await bedroomService.GetAllAsync().ContinueWith(antecendent => toBedroomDtoAdapterList(antecendent.Result)));
            AllCheckInList = (await checkInService.GetPendingCheckOutAsync().ContinueWith(antecendent => toCheckInAdapterList(antecendent.Result)));
        }

        private void createListOfGuests()
        {
            if (currentAvailableBedroom != null)
            {
                GuestList = new List<GuestDto>();
                for (int i = 1; i <= currentAvailableBedroom.Size; i++)
                {
                    GuestList.Add(new GuestDto());
                }
                CheckIn.Guests = GuestList;
            }
            else
            {
                GuestList = new List<GuestDto>();
            }
        }

        private bool IsCheckInOk(CheckInDto checkIn)
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
                Managers.EventManager.OnUpdateBedroomButtonPressed(this, CurrentBedroom.ToBedroomDto());
        }

        public void DeleteBedroomAction()
        {
            if (CurrentBedroom != null)
                Managers.EventManager.OnDeleteBedroomButtonPressed(this, CurrentBedroom.ToBedroomDto());
        }

        public  void CheckTheInvoiceAction()
        {
            CheckIn.Bedroom = currentAvailableBedroom;
            
            if (IsCheckInOk(CheckIn.ToCheckInDto()))
            {
                Managers.EventManager.OnCheckTheInvoiceButtonPressed(this, CheckIn.ToCheckInDto());
            }
        }

        public void CreateNewBedroomAction()
        {
            Managers.EventManager.OnCreateNewBedroomButtonPressed(this,new EventArgs());
        }

        public void DeleteCheckInAction()
        {
            if(CurrentCheckIn!=null)
            Managers.EventManager.OnDeleteCheckInButtonPressed(this,CurrentCheckIn.ToCheckInDto());
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
