using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.TakeSkip_Rope
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<int> listDigits = new List<int>();
            List<string> listNonDigit = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                int digit;
                if( int.TryParse(input[i].ToString(), out digit))
                {
                    listDigits.Add(digit);
                }
                else
                {
                    listNonDigit.Add(input[i].ToString());
                }

            }

            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();

            for (int i = 0; i < listDigits.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(listDigits[i]);
                }
                else
                {
                    skipList.Add(listDigits[i]);
                }

            }

            string message = string.Empty;
            // StringBuilder stBulder = new StringBuilder();
            string finalmessage = string.Empty;
            listNonDigit.ForEach(let => message+=let);
            int starIndex = 0;

            for (int i = 0; i < takeList.Count; i++)
            {
                int takeNumber = takeList[i];
                int skipNumber = skipList[i];


                string temp = string.Empty;
                temp= message.Substring(starIndex, takeNumber);

                finalmessage += temp;
                //stBulder.
                starIndex += takeNumber + skipNumber;

            }
            Console.WriteLine(finalmessage);


        }
    }
}
