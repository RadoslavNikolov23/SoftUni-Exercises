using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace _05.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            string singleDigit = Console.ReadLine();

            var productResult = MultiplyTheStrings(bigNumber, int.Parse(singleDigit));
            Console.WriteLine(productResult);

        }

        private static string MultiplyTheStrings(string bigNumber, int digit)
        {
            string finalResult = string.Empty;

            if(bigNumber=="0" || digit == 0)
            {
                return "0";
            }

            int result = 0;
            int firstnumber = 0;
            for (int i = bigNumber.Length-1; i >=0; i--)
            {
                int number = bigNumber[i] - '0';
               
                if (result > 10)
                {
                    result = (number * digit) + firstnumber;

                }
                else
                {

                    result = number * digit;
                }
               

                if (result > 10)
                {
                    firstnumber = result / 10;
                    int lastnumber = result % 10;
                    finalResult += lastnumber.ToString();

                    if (i == 0)
                    {
                        finalResult += firstnumber.ToString();
                    }

                }
                else
                {
                    finalResult += result.ToString();
                }

            }
            

            
            
            char[] chars = finalResult.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }
    }
}
