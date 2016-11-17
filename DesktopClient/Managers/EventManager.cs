using System;
using DesktopClient.EventArgsExtenctions;
using DesktopClient.Model;

namespace DesktopClient.Managers
{
     class EventManager
    {
        #region UserLoggedInEventHandler Members

        public static string UserName { get; private set; }

        public delegate void UserLoggedInEventHandler(object source, UserEventArgs eventArgs);

        public static event UserLoggedInEventHandler UserLoggedIn;

        public static void OnUserLoggedIn(object source, string userName)
        {
            UserName = userName;
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

        public static Bedroom Bedroom { get; private set; }

        public delegate void SaveNewBedroomButtonPressedEventHandler(object source, BedroomEventArgs eventArgs);

        public static event SaveNewBedroomButtonPressedEventHandler SaveNewBedroomButtonPressed;

        public static void OnSaveNewBedroomButtonPressed(object source, Bedroom bedroom)
        {
            Bedroom = bedroom;
            if (SaveNewBedroomButtonPressed != null)
            {
                SaveNewBedroomButtonPressed(source, new BedroomEventArgs(bedroom));
            }
        }

        #endregion

        #region UpdateBedroomButtonPressedEventHandler Members

        public static Bedroom BedroomToUpdate { get; private set; }

        public delegate void UpdateBedroomButtonPressedEventHandler(object source, BedroomEventArgs eventArgs);

        public static event UpdateBedroomButtonPressedEventHandler UpdateBedroomButtonPressed;

        public static void OnUpdateBedroomButtonPressed(object source, Bedroom bedroomToUpdate)
        {
            BedroomToUpdate = bedroomToUpdate;
            if (UpdateBedroomButtonPressed != null)
            {
                UpdateBedroomButtonPressed(source, new BedroomEventArgs(bedroomToUpdate));
            }
        }

        #endregion

        #region UpdateBedroomButtonPressedEventHandler Members

        public static Bedroom BedroomToDelete { get; private set; }

        public delegate void DeleteBedroomButtonPressedEventHandler(object source, BedroomEventArgs eventArgs);

        public static event DeleteBedroomButtonPressedEventHandler DeleteBedroomButtonPressed;

        public static void OnDeleteBedroomButtonPressed(object source, Bedroom bedroomToDelete)
        {
            BedroomToDelete = BedroomToDelete;
            if (DeleteBedroomButtonPressed != null)
            {
                DeleteBedroomButtonPressed(source, new BedroomEventArgs(bedroomToDelete));
            }
        }

        #endregion

        #region SaveCheckInButtonPressedEventHandler Members

        public static CheckIn CheckIn { get; private set; }

        public delegate void SaveCheckInButtonPressedEventHandler(object source, CheckInEventArgs eventArgs);

        public static event SaveCheckInButtonPressedEventHandler SaveCheckInButtonPressed;

        public static void OnSaveCheckInButtonPressed(object source, CheckIn checkIn)
        {
            CheckIn = checkIn;
            if (SaveCheckInButtonPressed != null)
            {
                SaveCheckInButtonPressed(source, new CheckInEventArgs(checkIn));
            }
        }

        #endregion

        #region DeleteCheckInButtonPressedEventHandler Members

        public static CheckIn CheckInToDelete { get; private set; }

        public delegate void DeleteCheckInButtonPressedEventHandler(object source, CheckInEventArgs eventArgs);

        public static event DeleteCheckInButtonPressedEventHandler DeleteCheckInButtonPressed;

        public static void OnDeleteCheckInButtonPressed(object source, CheckIn checkIn)
        {
            CheckInToDelete = checkIn;
            if (DeleteCheckInButtonPressed != null)
            {
                DeleteCheckInButtonPressed(source, new CheckInEventArgs(checkIn));
            }
        }

        #endregion

    }
}
