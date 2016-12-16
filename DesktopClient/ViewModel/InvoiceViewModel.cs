using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using DesktopClient.Commands;
using DomainModel.DataContracts;

namespace DesktopClient.ViewModel
{
    class InvoiceViewModel:INotifyPropertyChanged
    {
        private CheckInDto checkIn;
        public string ArrivingDate { get; set; }
        public string DepartureDate { get; set; }
        public string Bedroom { get; set; }
        public string Guests { get; set; }
        public string Size { get; set; }
        public string BathroomType { get; set; }
        public string BedType { get; set; }
        public string Price { get; set; }

        public ICommand CancelInvoice { get; private set; }
        public ICommand SaveCheckInAndPrintInvoice { get;private set; }


        public InvoiceViewModel(CheckInDto checkIn)
        {
            this.checkIn = checkIn;
            ArrivingDate = checkIn.ArrivingDate.ToShortDateString();
            DepartureDate = checkIn.DepartureDate.ToShortDateString();
            Bedroom = checkIn.Bedroom.Number.ToString();
            StringBuilder guests = new StringBuilder();
            foreach (var guest in checkIn.Guests)
            {
                guests.Append(guest.Name + " " + guest.Surname + "\n");
            }
            Guests = guests.ToString();
            Size = checkIn.Bedroom.Size.ToString();
            BathroomType = checkIn.Bedroom.BathroomType.Name;
            BedType = checkIn.Bedroom.BedType.Name;
            Price = checkIn.Bedroom.Price.ToString();
            CancelInvoice = new CancelInvoiceCommand(this);
            SaveCheckInAndPrintInvoice = new SaveCheckInAndPrintInvoiceCommand(this);
        }

        public void CancelInvoiceAction()
        {
            Managers.EventManager.OnCancelInvoiceButtonPressed(this,new EventArgs());
        }

        public void SaveCheckInAndPrintInvoiceAction()
        {
            Managers.EventManager.OnSaveCheckInAndPrintInvoiceButtonPressed(this, checkIn);
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
