using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Radio
{
    public static class NetUtils
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static bool InternetGetConnected()
        {
            return InternetGetConnectedState(out _, 0);
        }
    }
}
