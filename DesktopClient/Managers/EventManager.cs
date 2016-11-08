using DesktopClient.EventArgsExtenctions;

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
    }
}
