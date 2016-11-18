using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DesktopClient.Commands;
using DesktopClient.EventArgsExtenctions;
using DesktopClient.Model;

namespace DesktopClient.ViewModel
{
    public class BedroomEditorViewModel : INotifyPropertyChanged
    {
        private Bedroom newBedroom;
        public Bedroom NewBedroom
        {
            get
            {
                return newBedroom;
            }
            set
            {
                newBedroom = value;
                OnPropertyChanged();
            }
        }

        private string newBedType;
        public string NewBedType
        {
            get { return newBedType; }
            set
            {
                newBedType = value;
                OnPropertyChanged();
            }
        }

        private string newBathroomType;
        public string NewBathroomType
        {
            get { return newBathroomType; }
            set
            {
                newBathroomType = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveBedroom { get; private set; }

        private bool canExecuteSaveBedroom;
        public bool CanExecuteSaveBedroom
        {
            get { return canExecuteSaveBedroom; }
            private set
            {
                canExecuteSaveBedroom = value;
                OnPropertyChanged();
            }
        }

        public BedroomEditorViewModel()
        {
            NewBedroom = new Bedroom();
            SaveBedroom = new SaveBedroomCommand(this);
            CanExecuteSaveBedroom = true;
        }

        public BedroomEditorViewModel(BedroomEventArgs eventArgs)
        {
            NewBedroom=eventArgs.Bedroom;
            NewBedType = eventArgs.Bedroom.BedType.Name;
            NewBathroomType = eventArgs.Bedroom.BathroomType.Name;
            SaveBedroom=new SaveBedroomCommand(this);
            CanExecuteSaveBedroom = true;
        }

        public void SaveBedroomAction()
        {
            newBedroom.Available = true;
            newBedroom.BathroomType = new BathroomType(newBathroomType);
            newBedroom.BedType =new BedType( newBedType);
            Managers.EventManager.OnSaveNewBedroomButtonPressed(this, newBedroom);
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
