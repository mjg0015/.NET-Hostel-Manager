using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

        public CheckIn CheckIn { get; set; }
        public List<Bedroom> AvailableRoomsList { get;  set; }
        public List<Bedroom> AllRoomsList { get; set; }
        public List<CheckIn> AllCheckInList { get; set; }  
        public string ManagerName { get; }
        public List<int> Array { get; set; }

        private string currentBedroom ;

        public string CurrentBedroom
        {
            get { return currentBedroom; }
             set
            {
                currentBedroom = value;
                createListOfGuests();
                OnPropertyChanged();
            }
        } 

        private void createListOfGuests()
        {
            GuestList = new List<Guest>();
            var a = int.Parse(currentBedroom.Substring(currentBedroom.Length - 2));
            for (int i = 0; i < a; i++)
            {
                GuestList.Add(new Guest());
            }
            CheckIn.Guests = GuestList;
        }

        public CheckInManagementViewModel(UserEventArgs userEventArgs)
        {
            SaveCheckIn=new SaveCheckInCommand(this);
            ManagerName = userEventArgs.UserName;
            initializeProperties();
            canExecuteSaveCheckIn = true;
        }

        private void initializeProperties()
        {
            CheckIn = new CheckIn();
            CheckIn.ArrivingDate = DateTime.Today;
            CheckIn.DepartureDate = DateTime.Today.AddDays(1);
           

            //Guest.BirthDate = DateTime.Today ;
            //Bedroom service usage example:
            IBedroomService bedroomServ = new BedroomService();
            AvailableRoomsList = bedroomServ.GetAvailable();
            AllRoomsList = bedroomServ.GetAll();
            
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
