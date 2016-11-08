using System;

namespace DesktopClient.EventArgsExtenctions
{
    public class UserEventArgs : EventArgs
    {
        public string UserName { get; private set; }

        public UserEventArgs(string userName)
        {
            UserName = userName;
        }
    }
}
