using System;
using DesktopClient.EventArgsExtenctions;
using DomainModel.DataContracts;

namespace DesktopClient.Managers
{
     class EventManager
    {
        #region UserLoggedInEventHandler Members

        public delegate void UserLoggedInEventHandler(object source, UserEventArgs eventArgs);

        public static event UserLoggedInEventHandler UserLoggedIn;

        public static void OnUserLoggedIn(object source, string userName)
        {
            if (UserLoggedIn != null)
            {
                UserLoggedIn(source, new UserEventArgs(userName));
            }
        }

        #endregion

        #region CreateNewBedroomButtonPressedEventHandler Members

        public delegate void CreateNewBedroomButtonPressedEventHandler(object source, EventArgs eventArgs);

        public static event CreateNewBedroomButtonPressedEventHandler CreateNewBedroomButtonPressed;

        public static void OnCreateNewBedroomButtonPressed(object source, EventArgs eventArgs )
        {
          
            if (CreateNewBedroomButtonPressed != null)
            {
                CreateNewBedroomButtonPressed(source, new EventArgs());
            }
        }

        #endregion

        #region SaveNewBedroomButtonPressedEventHandler Members

        public delegate void SaveNewBedroomButtonPressedEventHandler(object source, BedroomEventArgs eventArgs);

        public static event SaveNewBedroomButtonPressedEventHandler SaveNewBedroomButtonPressed;

        public static void OnSaveNewBedroomButtonPressed(object source, BedroomDto bedroom)
        {
            if (SaveNewBedroomButtonPressed != null)
            {
                SaveNewBedroomButtonPressed(source, new BedroomEventArgs(bedroom));
            }
        }

        #endregion

        #region UpdateBedroomButtonPressedEventHandler Members

        public delegate void UpdateBedroomButtonPressedEventHandler(object source, BedroomEventArgs eventArgs);

        public static event UpdateBedroomButtonPressedEventHandler UpdateBedroomButtonPressed;

        public static void OnUpdateBedroomButtonPressed(object source, BedroomDto bedroomToUpdate)
        {
            if (UpdateBedroomButtonPressed != null)
            {
                UpdateBedroomButtonPressed(source, new BedroomEventArgs(bedroomToUpdate));
            }
        }

        #endregion

        #region UpdateBedroomButtonPressedEventHandler Members

        public delegate void DeleteBedroomButtonPressedEventHandler(object source, BedroomEventArgs eventArgs);

        public static event DeleteBedroomButtonPressedEventHandler DeleteBedroomButtonPressed;

        public static void OnDeleteBedroomButtonPressed(object source, BedroomDto bedroomToDelete)
        {
            if (DeleteBedroomButtonPressed != null)
            {
                DeleteBedroomButtonPressed(source, new BedroomEventArgs(bedroomToDelete));
            }
        }

        #endregion

        #region CheckTheInvoiceButtonPressedEventHandler Members



        public delegate void CheckTheInvoiceButtonPressedEventHandler(object source, CheckInEventArgs eventArgs);

        public static event CheckTheInvoiceButtonPressedEventHandler CheckTheInvoiceButtonPressed;

        public static void OnCheckTheInvoiceButtonPressed(object source, CheckInDto checkIn)
        {
           
            if (CheckTheInvoiceButtonPressed != null)
            {
                CheckTheInvoiceButtonPressed(source, new CheckInEventArgs(checkIn));
            }
        }

        #endregion

        #region DeleteCheckInButtonPressedEventHandler Members

        public static CheckInDto CheckInToDelete { get; private set; }

        public delegate void DeleteCheckInButtonPressedEventHandler(object source, CheckInEventArgs eventArgs);

        public static event DeleteCheckInButtonPressedEventHandler DeleteCheckInButtonPressed;

        public static void OnDeleteCheckInButtonPressed(object source, CheckInDto checkIn)
        {
            CheckInToDelete = checkIn;
            if (DeleteCheckInButtonPressed != null)
            {
                DeleteCheckInButtonPressed(source, new CheckInEventArgs(checkIn));
            }
        }

        #endregion

        #region CancelInvoiceButtonPressedEventHandler Members

        public delegate void CancelInvoiceButtonPressedEventHandler(object source, EventArgs eventArgs);

        public static event CancelInvoiceButtonPressedEventHandler CancelInvoiceButtonPressed;

        public static void OnCancelInvoiceButtonPressed(object source, EventArgs eventArgs)
        {
            if (CancelInvoiceButtonPressed != null)
            {
                CancelInvoiceButtonPressed(source, new EventArgs());
            }
        }

        #endregion

        #region SaveCheckInAndPrintInvoiceButtonPressedEventHandler Members

        public delegate void SaveCheckInAndPrintInvoiceButtonPressedEventHandler(object source, CheckInEventArgs eventArgs);

        public static event SaveCheckInAndPrintInvoiceButtonPressedEventHandler SaveCheckInAndPrintInvoiceButtonPressed;

        public static void OnSaveCheckInAndPrintInvoiceButtonPressed(object source, CheckInDto checkIn)
        {
            if (SaveCheckInAndPrintInvoiceButtonPressed != null)
            {
                SaveCheckInAndPrintInvoiceButtonPressed(source, new CheckInEventArgs(checkIn));
            }
        }

        #endregion
    }
}
