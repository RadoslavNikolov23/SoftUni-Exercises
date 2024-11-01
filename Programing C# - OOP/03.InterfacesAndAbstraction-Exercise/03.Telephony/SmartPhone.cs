using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class Smartphone : ICall, IBrowse
    {
        public string Browse(string website)
        {
            return $"Browsing: {website}!";
        }

        public string Call (string phonenumber)
        {
            return $"Calling... {phonenumber}";
        }  
 
    }
}
