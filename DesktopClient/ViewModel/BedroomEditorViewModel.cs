using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DesktopClient.Commands;
using DesktopClient.EventArgsExtenctions;
using DesktopClient.Model;

namespace DesktopClient.ViewModel
{
    class BedroomEditorViewModel : INotifyPropertyChanged
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
            NewBedroom=new Bedroom();
            SaveBedroom=new SaveBedroomCommand(this);
            CanExecuteSaveBedroom = true;
        }

        public void SaveBedroomAction()
        {
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
