using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class StationaryPhone : ICall
    {

        public string Call(string phonenumber)
        {
            return $"Dialing... {phonenumber}";
        }
    }
}
