using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
    public class DateModifier
    {

        public string FirstDateTime {get; set;}
        public string SecondDateTime {get; set;}

        public int CalculateDateDiffrence(string firstDateTime, string secondDateTime)
        {
            DateTime firstDate=DateTime.Parse(firstDateTime);
            DateTime secondDate=DateTime.Parse(secondDateTime);

            TimeSpan diffrenceResult=firstDate-secondDate;

            return Math.Abs(diffrenceResult.Days);
        }
    }
}
