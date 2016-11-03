using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
