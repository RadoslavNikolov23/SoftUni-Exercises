using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string temp = input;
                var dataInt=0;
                var dataFloat = 0.0f;
                var dataBool = false;
                var dataChar = ' ';

                if (int.TryParse(input, out dataInt))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else if (float.TryParse(input, out dataFloat))
                {
                    Console.WriteLine($"{input} is floating point type");
                }
                else if(bool.TryParse(input,out dataBool))
                {
                    Console.WriteLine($"{ input} is boolean type");
                }
                else if (char.TryParse(input, out dataChar))
                {
                    Console.WriteLine($"{ input} is character type");
                }
                else
                {
                    Console.WriteLine($"{ input} is string type");
                }




            }

        }
    }
}
