using System;

namespace _01.DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (input=="int")
            {
                int numberInteger = int.Parse(Console.ReadLine());
                GetResult(numberInteger);
            }
            else if(input =="float" || input =="real" || input=="double" || input == "decimal")
            {
                double numberDouble = double.Parse(Console.ReadLine());
                GetResult(numberDouble);
            }
            else if (input == "string")
            {
                string stringInput = Console.ReadLine();
                GetResult(stringInput);
            }

        }

        private static void GetResult(int numberInteger)
        {
            int outPut = numberInteger * 2;
            Console.WriteLine(outPut);
        }

        private static void GetResult(double numberDouble)
        {
            double outPut = numberDouble * 1.5;
            Console.WriteLine($"{outPut:f2}");
        }
        private static void GetResult(string stringInput)
        {
            string output = $"${stringInput}$";
            Console.WriteLine(output);
        }
    }
}
